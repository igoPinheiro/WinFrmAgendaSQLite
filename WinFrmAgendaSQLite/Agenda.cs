using System.Data;

namespace WinFrmAgendaSQLite;
public partial class Agenda : Form
{
    public Agenda()
    {
        InitializeComponent();
    }

    private void Agenda_Load(object sender, EventArgs e)
    {
        try
        {
            DAOAgenda.CreateBancoSQLite();
            DAOAgenda.CreateTableSQLite();

            ShowData();

            lblData.Text = DAOAgenda.path;
        }
        catch (Exception ex)
        {
            btnAlt.Enabled = btnDel.Enabled = btnIns.Enabled = btnLoc.Enabled = false;
            ShowErrorMsg(ex);
        }
    }

    private void btnIns_Click(object sender, EventArgs e)
    {
        try
        {
            var model = new Contact(GetIDValue(), txtName.Text, txtEmail.Text);

            model.Validate();

            var r = DAOAgenda.GetContact(model.Id ?? throw new Exception("Id Não identificado!"));

            if (r?.Rows?.Count > 0) throw new Exception($"Já existe um registro com ID {model.Id}");

            DAOAgenda.Add(model);

            ShowData();

            ClearForm();
        }
        catch (Exception ex)
        {
            ShowErrorMsg(ex);
        }
    }

    private void btnAlt_Click(object sender, EventArgs e)
    {
        try
        {
            var model = new Contact(GetIDValue(), txtName.Text, txtEmail.Text);

            model.Validate();

            DAOAgenda.Update(model);

            ShowData();

            ClearForm();
        }
        catch (Exception ex)
        {
            ShowErrorMsg(ex);
        }
    }

    private void btnDel_Click(object sender, EventArgs e)
    {
        try
        {
            if (gv.SelectedCells.Count > 0)
            {
                int rowindex = gv.SelectedCells[0].RowIndex;

                var id = gv["id", rowindex]?.Value?.ToString();

                if (!string.IsNullOrEmpty(id))
                {
                    if (MessageBox.Show($"Tem certeza que você quer excluir o contato ID [{id}]?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        DAOAgenda.Delete(Convert.ToInt32(id));

                        ShowData();

                        ClearForm();
                    }
                }
            }
        }
        catch (Exception ex)
        {

            MessageBox.Show("ERROR:" + ex.Message);
        }
    }

    private void ClearForm()
    {
        txtEmail.Clear();
        txtID.Clear();
        txtName.Clear();
    }

    private void ShowData()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = DAOAgenda.GetContacts();
            gv.DataSource = dt;
        }
        catch (Exception ex)
        {
            ShowErrorMsg(ex);
        }
    }

    private void ShowErrorMsg(Exception ex)
    {
        MessageBox.Show("ERROR:" + ex.Message);
    }

    private void txtID_KeyPress(object sender, KeyPressEventArgs e)
    {
        //Permiti somente digitos
        e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        ClearForm();
    }

    private void gv_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
            return;

        txtID.Text = gv[nameof(Contact.Id), e.RowIndex]?.Value?.ToString();
        txtName.Text = gv[nameof(Contact.Name), e.RowIndex]?.Value?.ToString();
        txtEmail.Text = gv[nameof(Contact.Email), e.RowIndex]?.Value?.ToString();
    }

    private int? GetIDValue()
    {
        if (string.IsNullOrEmpty(txtID.Text?.Trim()))
            return null;

        return Convert.ToInt32(txtID.Text.Trim());
    }

}