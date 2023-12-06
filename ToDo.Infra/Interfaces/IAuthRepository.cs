using ToDo.Domain.Entities;

namespace ToDo.Infra.Interfaces;

public interface IAuthRepository
{
    Task<User> Get(string email);
}