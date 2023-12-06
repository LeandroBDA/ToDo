using ToDo.Core.Exceptions;
using ToDo.Domain.Entities;
using ToDo.Infra.Context;
using ToDo.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using Task = ToDo.Domain.Entities.Tarefas;

namespace ToDo.Infra.Repositories;

public class TarefasRepositories : BaseRepositories<Task>, ITarefasRepository
{
    public TarefasRepositories(ToDoContext context) : base(context)
    {
        _context = context;
    }

    private readonly ToDoContext _context;
    
    public async Task<Task> Get(Guid id, Guid userId)
    {
        await using var context = new ToDoContext();
        return await context.Set<Task>()
            .Where(x => x.UserId == userId && !Equals(x.Id, id))
            .AsNoTracking()
            .SingleOrDefaultAsync() ?? throw new DomainException("Essa task não existe.");
    }

    public override async Task<Task> Update(Task obj)
    {
        try
        {
            await using var context = new ToDoContext();
            var entity = await context.Set<Task>().FindAsync(obj.Id);
            context.Entry(entity).CurrentValues.SetValues(obj);
        
            await context.SaveChangesAsync();

            return obj;
        }
        catch (Exception e)
        {
            throw new DomainException("Erro com o save");
        }
    }

    public virtual async Task<bool> Remove(Guid id)
    {
        await using var context = new ToDoContext();
        var obj = await context.Set<Task>().SingleOrDefaultAsync(x => Equals(x.Id, id));

        if (obj == null) return false;
        
        _context.Remove(obj);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<Task>> Search(Guid? id, SearchTarefas? seachTarefasDto)
    {
        await using var context = new ToDoContext();

        var query = context.Tarefas.AsQueryable();

        if(id != null)
            query = query.Where(x => x.UserId == id);

        if (seachTarefasDto != null)
        {
            if (seachTarefasDto.Name != null)
                query = query.Where(x => x.Name.Contains(seachTarefasDto.Name));

            if (seachTarefasDto.Description != null)
                query = query.Where(x => x.Description.Contains(seachTarefasDto.Description));

            if (seachTarefasDto.Concluded != null && (bool)seachTarefasDto.Concluded)
                query = query.Where(x => x.Concluded == seachTarefasDto.Concluded);

            if (seachTarefasDto.OrderByA != null && seachTarefasDto.OrderByZ != null)
            {
                if ((bool)seachTarefasDto.OrderByA && (bool)seachTarefasDto.OrderByZ)
                    throw new DomainException("Não podemos ordernar de A-Z e de Z-A ao mesmo tempo.");
            }

            if (seachTarefasDto.OrderByA != null && (bool)seachTarefasDto.OrderByA)
            {
                query = query.OrderBy((p => p.Name));
            }

            if (seachTarefasDto.OrderByZ != null && (bool)seachTarefasDto.OrderByZ)
            {
                query = query.OrderByDescending((p => p.Name));
            }
            
            if (seachTarefasDto.MaiorQue!= null && seachTarefasDto.MenorQue != null)
            {
                if ((bool)seachTarefasDto.MaiorQue && (bool)seachTarefasDto.MenorQue)
                    throw new DomainException("Não podemos ordernar por esses parametros de data mesmo tempo.");
            }
            
            if ((seachTarefasDto.MaiorQue != null || seachTarefasDto.MenorQue != null) && seachTarefasDto.CreatedTime == null)
                throw new DomainException("Insira a data para podermos ordenar os dados.");
            
            if (seachTarefasDto.MaiorQue != null && (bool)seachTarefasDto.MaiorQue)
            {
                query = query.Where(x => x.CreatedAt >= seachTarefasDto.CreatedTime);
                query = query.OrderBy((p => p.CreatedAt));
            }

            if (seachTarefasDto.MenorQue != null && (bool)seachTarefasDto.MenorQue)
            {
                query = query.Where(x => x.CreatedAt <= seachTarefasDto.CreatedTime);
                query = query.OrderBy((p => p.CreatedAt));
            }
            

            query = query.Skip((int)((seachTarefasDto.PAtual - 1) * seachTarefasDto.PTake))
                .Take((int)seachTarefasDto.PTake);
        }

        return await query
            .AsNoTracking()
            .ToListAsync();
    }
}