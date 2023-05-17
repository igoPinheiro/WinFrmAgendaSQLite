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
        //DAOAgenda.path
        DAOAgenda.CreateBancoSQLite();
        DAOAgenda.CreateTableSQLite();

        ShowData();

        lblData.Text = DAOAgenda.path;

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

            MessageBox.Show("ERROR:" + ex.Message);
        }
    }

    private void btnIns_Click(object sender, EventArgs e)
    {
        try
        {
            Contact c = new Contact();
            c.Id = Convert.ToInt32(txtID.Text);
            c.Name = txtName.Text;
            c.Email = txtEmail.Text;

            DAOAgenda.Add(c);

            ShowData();

            txtEmail.Clear();
            txtID.Clear();
            txtName.Clear();
        }
        catch (Exception ex)
        {

            MessageBox.Show("ERROR:" + ex.Message);
        }
    }

    private void btnAlt_Click(object sender, EventArgs e)
    {
        try
        {
            Contact c = new Contact();
            c.Id = Convert.ToInt32(txtID.Text);
            c.Name = txtName.Text;
            c.Email = txtEmail.Text;

            DAOAgenda.Update(c);

            ShowData();

            txtEmail.Clear();
            txtID.Clear();
            txtName.Clear();
        }
        catch (Exception ex)
        {

            MessageBox.Show("ERROR:" + ex.Message);
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

            txtEmail.Clear();
            txtID.Clear();
            txtName.Clear();
        }
        catch (Exception ex)
        {

            MessageBox.Show("ERROR:" + ex.Message);
        }
    }
}