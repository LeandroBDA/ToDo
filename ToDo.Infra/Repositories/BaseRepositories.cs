using ToDo.Core.Exceptions;
using ToDo.Domain.Entities;
using ToDo.Infra.Context;
using ToDo.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using Task = ToDo.Domain.Entities.Tarefas;

namespace ToDo.Infra.Repositories;

public class BaseRepositories<T> : IBaseRepository<T> where T : Base
{
    private readonly ToDoContext _context;

    public BaseRepositories(ToDoContext context)
    {
        _context = context;
    }

    public virtual async Task<T> Create(T obj)
    {
        _context.Add(obj);
        await _context.SaveChangesAsync();

        return obj;
    }

    public virtual async Task<T> Update(T obj)
    {
        try
        {
            var entity = await _context.Set<T>().FindAsync(obj.Id);
            _context.Entry(entity).CurrentValues.SetValues(obj);
        
            await _context.SaveChangesAsync();

            return obj;
        }
        catch (Exception e)
        {
            throw new DomainException("Erro com o save");
        }
    }

    public virtual async Task<T> Get(Guid id)
    {
        await using var context = new ToDoContext();
        return await context.Set<T>().FindAsync(id) ?? throw new DomainException("Não foi encontrado nenhum resultado para essa pesquisa.");
    }

    public virtual async Task<List<T>> Get()
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .ToListAsync();
    }
}