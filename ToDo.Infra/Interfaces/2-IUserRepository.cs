using Manager.Domain.Entites;

namespace ToDo.Infra.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> Get(Guid id);
        Task<bool> Remove(Guid id);
        Task<User> GetByEmail(string email);
        Task<List<User>> SearchByEmail(string email);
        Task<List<User>> SearchByName(string name);
    }
}

