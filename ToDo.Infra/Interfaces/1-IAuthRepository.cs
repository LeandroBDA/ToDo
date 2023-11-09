
using Manager.Domain.Entites;

namespace ToDo.Infra.Interfaces
{
    public interface IAuthRepository
    {
        Task<User?> Get(string Email);
    }
}

