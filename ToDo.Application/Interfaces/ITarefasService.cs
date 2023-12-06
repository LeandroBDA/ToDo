using ToDo.Domain.Entities;
using ToDo.Services.DTO.Tasks;
using Task = System.Threading.Tasks.Task;

namespace ToDo.Services.Interfaces;

public interface ITarefasService
{
    Task<CreateTarefasDTO> Create(CreateTarefasDTO tasksDto);
    Task<TarefasDTO> Update(TarefasDTO tasksDto);
    Task Remove(Guid UserId, Guid id);
    Task<TarefasDTO> Get(Guid id, Guid userId);
    Task<List<TarefasDTO>> Search(Guid? id, SearchTarefas? searchTarefas);
}