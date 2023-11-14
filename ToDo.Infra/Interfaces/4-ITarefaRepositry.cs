using ToDo.Domain.Validators;

namespace ToDo.Infra.Interfaces;

public interface ITaskRepository : IBaseRepository<Task>
{
    Task<Tarefa> Get(int id, int userId);
    Task<bool> Remove(int id);
}
