using ToDo.Domain.Validators;

namespace ToDo.Infra.Interfaces;

public interface ITaskRepository : IBaseRepository<Task>
{
    Task<Tasks> Get(Guid id, Guid userId);
    Task<bool> Remove(Guid id);
    // Task<List<Tasks>> Search<SearchTask>(Guid id, SearchTask searchTask); //Paginaçaõ, fazer no final
}
