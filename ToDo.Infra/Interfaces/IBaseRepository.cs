using ToDo.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace ToDo.Infra.Interfaces;

public interface IBaseRepository<T>
{
    Task<T> Create(T obj);
    Task<T> Update(T obj);
    Task<T> Get(Guid id);
    Task<List<T>> Get();
}