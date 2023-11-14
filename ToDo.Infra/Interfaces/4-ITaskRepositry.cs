using ToDo.Domain.Validators;

namespace ToDo.Infra.Interfaces;

public interface ITaskRepository : IBaseRepository<Task>
{
    Task<Tasks> Get(int id, int userId);
    Task<bool> Remove(int id);
    // Task<List<Tasks>> Search<SearchTask>(Guid id, SearchTask searchTask); //Paginaçaõ, fazer no final
}
