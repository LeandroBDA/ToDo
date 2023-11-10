
using ToDo.Domain.Validators;

namespace ToDo.Infra.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> Create(T obj);
        Task<T> Update(T obj);
        Task<Tasks?> GetById(Guid id);
        Task<List<T>> Search();
    }
}

