namespace Crud.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Role { get; set; }
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
}