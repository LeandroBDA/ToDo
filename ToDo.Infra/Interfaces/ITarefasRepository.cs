using ToDo.Domain.Entities;
using Task = ToDo.Domain.Entities.Tarefas;

namespace ToDo.Infra.Interfaces;

public interface ITarefasRepository : IBaseRepository<Tarefas>
{

    Task<Task> Get(Guid id, Guid userId);
    Task<bool> Remove(Guid id);
    Task<List<Task>> Search(Guid? id, SearchTarefas? searchTask);

}


