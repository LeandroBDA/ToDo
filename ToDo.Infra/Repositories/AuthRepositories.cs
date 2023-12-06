using ToDo.Core.Exceptions;
using ToDo.Domain.Entities;
using ToDo.Infra.Context;
using ToDo.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using Task = ToDo.Domain.Entities.Tarefas;

namespace Manager.Infra.Repositories;

public class AuthRepositories : IAuthRepository
{
    public AuthRepositories()
    {
        
    }
    
    public AuthRepositories(ToDoContext context)
    {
        _context = context;
    }
    
    private readonly ToDoContext _context;
    
    public async Task<User> Get(string email)
    {
        var context = new ToDoContext();
        return await context.Set<User>()
            .Where(x => x.Email == email)
            .AsNoTracking()
            .SingleOrDefaultAsync() ?? throw new InvalidOperationException();
    }
}