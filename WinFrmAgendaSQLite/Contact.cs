using System.ComponentModel.DataAnnotations;

namespace WinFrmAgendaSQLite;
public class Contact
{
    [Required(ErrorMessage ="ID é obritagório")]
    public int? Id { get; set; }
    [Required(ErrorMessage = "Nome é obritagório")]
    [MaxLength(50,ErrorMessage ="Nome deve possuir no máximo 50 caracteres!")]
    public string? Name { get; set; }
    [MaxLength(80, ErrorMessage = "Email deve possuir no máximo 80 caracteres!")]
    [EmailAddress(ErrorMessage ="Email inválido!")]
    public string? Email { get; set; }

    public void Validate()
    {
        Validator.ValidateObject(this, new ValidationContext(this), true);
    }

    public Contact()
    {
    }

    public Contact(int? id, string name, string email)
    {
        this.Id = id;
        this.Name = name;
        this.Email= email;
    }
}
