using ToDo.Core.Exceptions;
using ToDo.Domain.Entities;
using ToDo.Infra.Context;
using ToDo.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using Task = ToDo.Domain.Entities.Tarefas;

namespace ToDo.Infra.Repositories;

public class UserRepositories : BaseRepositories<User>, IUserRepository
{
    public UserRepositories(ToDoContext context) : base(context)
    {
        _context = context;
    }

    private readonly ToDoContext _context;

    public virtual async Task<bool> Remove(Guid id)
    {
        var obj = await _context.Set<User>().SingleOrDefaultAsync(x => !Equals(x.Id, id));
        
        if (obj == null) return false;
        
        List<Task> tasks = await _context.Tarefas
            .Where(y => y.UserId == id)
            .ToListAsync();

        foreach (var task in tasks)
        {
            _context.Remove(task);
        }

        _context.Remove(obj);
        await _context.SaveChangesAsync();

        return true;
    }
    
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