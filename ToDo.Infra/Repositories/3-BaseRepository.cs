// using ToDo.Infra.Context;
// using ToDo.Infra.Interfaces;
// using Microsoft.EntityFrameworkCore;
// using ToDo.Core.Exceptions;
// using ToDo.Domain.Entites;
// using ToDo.Domain.Validators;
//
// namespace ToDo.Infra.Repositories;
//
// public class BaseRepository<T> : IBaseRepository<T> where T : Base
// {
//     private readonly ToDoContext _context;
//     public BaseRepository(ToDoContext context)
//     {
//         _context = context;
//     }
//     public virtual async Task<T> Create(T obj)
//     {
//         _context.Add(obj);
//         await _context.SaveChangesAsync();
//
//         return obj;
//     }
//     public virtual async Task<T> Update(T obj)
//     {
//         _context.Update(obj);
//         await _context.SaveChangesAsync();
//
//         return obj;
//     }
//     public virtual async Task<Tasks?> GetById(Guid id)
//     {
//         await using var context = new ToDoContext();
//         return await context.Set<T>().FindAsync(id) ?? throw new DomainException("Não foi encontrado nenhum resultado");
//     }
//     public virtual async Task<List<T>> Search()
//     {
//         return await _context.Set<T>()
//             .AsNoTracking()
//             .ToListAsync();
//     }
// }