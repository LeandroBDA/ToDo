namespace ToDo.Services.DTO.Tasks;

public class RemoveTarefasDTO
{
    public RemoveTarefasDTO(Guid id, Guid userId)
    {
        Id = id;
        UserId = userId;
    }

    public Guid Id { get; set; }
    public Guid UserId { get; set; }
}