using ToDo.Domain.Entites;
using ToDo.Domain.Entities;

namespace ToDo.Infra.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<List<User>> GetByEmail(string email);
        Task<List<User>> GetByName(string name);
        Task<List<User>> SearchByEmail(string email);
        Task<List<User>> SearchByName(string name);
    }
}

