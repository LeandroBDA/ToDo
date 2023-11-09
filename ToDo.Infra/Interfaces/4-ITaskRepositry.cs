namespace ToDo.Infra.Interfaces;

public interface ITaskRepository : IBaseRepository<Task>
{
    Task<Task> Get(Guid id, Guid userId);
    Task<bool> Remove(Guid id);
    Task<List<Task>> Search<SearchTask>(Guid id, SearchTask searchTask);
}
