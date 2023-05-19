namespace WinFrmAgendaSQLite;
public class Contact
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }

    public Contact()
    {

    }

    public Contact(int id, string name, string email)
    {
        this.Id = id;
        this.Name = name;
        this.Email= email;
    }
}
