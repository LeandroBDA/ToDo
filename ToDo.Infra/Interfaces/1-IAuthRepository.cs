
using ToDo.Domain.Entites;
using ToDo.Domain.Entities;

namespace ToDo.Infra.Interfaces
{
    public interface IAuthRepository
    {
        Task<User?> Get(string Email);
    }
}

