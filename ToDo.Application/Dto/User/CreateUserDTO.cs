namespace ToDo.Services.DTO.User;

public class CreateUserDTO
{
    public CreateUserDTO(string role, string name, string email, string password)
    {
        Id = Guid.NewGuid();
        Role = role;
        Name = name;
        Email = email;
        Password = password;
    }

    public Guid Id { get; set; }
    public string Role { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}