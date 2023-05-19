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
            DAOAgenda.Add(new Contact(Convert.ToInt32(txtID.Text), txtName.Text, txtEmail.Text));

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
            DAOAgenda.Update(new Contact(Convert.ToInt32(txtID.Text), txtName.Text, txtEmail.Text));

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
            foreach (DataGridViewCell row in gv.SelectedCells)
            {
                var id = gv["id", row.RowIndex]?.Value?.ToString();

                if (string.IsNullOrEmpty(id))
                    continue;

                DAOAgenda.Delete(Convert.ToInt32(id));

            }

            ShowData();

            ClearForm();
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
}