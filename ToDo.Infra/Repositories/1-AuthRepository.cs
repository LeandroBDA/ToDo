using ToDo.Domain.Entites;
using ToDo.Infra.Context;
using ToDo.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;

namespace ToDo.Infra.Repositories;

public class AuthRepository : IAuthRepository
{ 
    public AuthRepository()
    {
        
    }
    public AuthRepository(ToDoContext context)
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
