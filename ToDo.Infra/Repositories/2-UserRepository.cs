using ToDo.Domain.Entites;
using ToDo.Domain.Validators;
using ToDo.Infra.Context;
using ToDo.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;

namespace ToDo.Infra.Repositories;
public class UserRepository : BaseRepository<User>, IUserRepository
{ 
    public UserRepository(ToDoContext context) : base(context)
    {
        _context = context;
    }
    private readonly ToDoContext _context;
    
    public async Task<User?> GetByEmail(string email)
    {
        return await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
    }

    public async Task<List<User>> SearchByEmail(string email)
    {
        return await _context.Users
            .Where(x => x.Email.ToLower().Contains(email.ToLower()))
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<User>> SearchByName(string name)
    {
        return await _context.Users
            .Where(x => x.Name.ToLower().Contains(name.ToLower()))
            .AsNoTracking()
            .ToListAsync();
    }
}