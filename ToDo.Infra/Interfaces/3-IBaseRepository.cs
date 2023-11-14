
using ToDo.Domain.Validators;

namespace ToDo.Infra.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> Create(T obj);
        Task<T> Update(T obj);
        Task<T?> GetById(int id);
        Task<List<T>> Search();
        Task Remove(int id);
    }
}

