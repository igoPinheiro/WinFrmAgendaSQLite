using System.Data;
using System.Data.SQLite;

namespace WinFrmAgendaSQLite;
public class DAOAgenda 
{
    public static string path = Directory.GetCurrentDirectory() + "\\banco.sqlite";
    private static SQLiteConnection? SQLiteConnection;

    private static SQLiteConnection DBConnection()
    {
        SQLiteConnection = new SQLiteConnection("Data Source="+path);
        SQLiteConnection.Open();
        return SQLiteConnection;
    }

    public static void CreateBancoSQLite()
    {
        try
        {
            if (File.Exists(path) == false)
                SQLiteConnection.CreateFile(path);
        }
        catch (Exception e)
        {
            throw GetException(nameof(CreateBancoSQLite), e);
        }
    }

    public static void CreateTableSQLite()
    {
        try
        {
            using var cmd = DBConnection().CreateCommand();
            cmd.CommandText = "CREATE TABLE IF NOT EXISTS Contacts(id int,name varchar(50), email varchar(80))";
            cmd.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            throw GetException(nameof(CreateTableSQLite), e);
        }
    }

    public static DataTable GetContacts()
    {
        SQLiteDataAdapter da;
        DataTable dt = new();

        try
        {
            using var cmd = DBConnection().CreateCommand();
            cmd.CommandText = "SELECT * FROM Contacts";

            da = new SQLiteDataAdapter(cmd.CommandText, DBConnection());
            da.Fill(dt);
            return dt;
        }
        catch (Exception e)
        {
            throw GetException(nameof(GetContacts), e);
        }
    }

    public static DataTable GetContact(int id)
    {
        SQLiteDataAdapter da;
        DataTable dt = new();

        try
        {
            using var cmd = DBConnection().CreateCommand();
            cmd.CommandText = "SELECT * FROM Contacts WHERE id = " + id;

            da = new SQLiteDataAdapter(cmd.CommandText, DBConnection());
            da.Fill(dt);
            return dt;
        }
        catch (Exception e)
        {
            throw GetException(nameof(GetContact), e);
        }
    }

    public static void Add(Contact contact)
    {
        try
        {
            using var cmd = DBConnection().CreateCommand();
            cmd.CommandText = "INSERT INTO Contacts(id,name,email) VALUES(@id,@name,@email);";
            cmd.Parameters.AddWithValue("@id", contact.Id);
            cmd.Parameters.AddWithValue("@name", contact.Name);
            cmd.Parameters.AddWithValue("@email", contact.Email);
            cmd.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            throw GetException(nameof(Add), e);
        }
    }

    public static void Update(Contact contact)
    {
        try
        {
            using var cmd = DBConnection().CreateCommand();
            cmd.CommandText = "UPDATE Contacts SET Name = @Name, Email = @Email WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", contact.Id);
            cmd.Parameters.AddWithValue("@name", contact.Name);
            cmd.Parameters.AddWithValue("@email", contact.Email);
            cmd.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            throw GetException(nameof(Update), e);
        }
    }

    public static void Delete(int id)
    {
        try
        {
            using var cmd = DBConnection().CreateCommand();
            cmd.CommandText = "DELETE FROM Contacts WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            throw GetException(nameof(Delete),e);
        }
    }

    private static Exception GetException(string methodName, Exception ex)
    {
        return new Exception(string.Format("{0}: {1}",methodName,ex.Message));
    }
}
