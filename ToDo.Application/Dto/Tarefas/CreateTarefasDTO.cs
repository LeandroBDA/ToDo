namespace ToDo.Services.DTO.Tasks;

public class CreateTarefasDTO
{
    public CreateTarefasDTO()
    {
        
    }
    
    public CreateTarefasDTO(Guid userId, string name, string? description, DateTime? deadline)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Name = name;
        Description = description;
        CreatedAt = DateTime.Now;
        Concluded = false;
        Deadline = deadline;
    }

    
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool Concluded { get; set; }
    public DateTime? Deadline { get; set; }
}