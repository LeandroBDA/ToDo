// using ToDo.Infra.Context;
// using ToDo.Infra.Interfaces;
// using Microsoft.EntityFrameworkCore;
// using ToDo.Core.Exceptions;
// using ToDo.Domain.Validators;
//
// namespace ToDo.Infra.Repositories
// {
//     public class TasksRepository : BaseRepository<Tasks>, ITaskRepository
//     {
//         private readonly ToDoContext _context;
//
//         public TasksRepository(ToDoContext context) : base(context)
//         {
//             _context = context;
//         }
//
//         public virtual async Task<Task> Create(Task obj)
//         {
//             _context.Add(obj);
//             return _context.SaveChangesAsync();
//         }
//
//         public virtual async Task<bool> Update(Task obj)
//         {
//             _context.Update(obj);
//             await _context.SaveChangesAsync();
//
//             return true;
//         }
//         
//
//         public async Task<Tasks?> GetById(Guid id)
//         {
//             return await _context.Tasks
//                 .AsNoTracking()
//                 .FirstOrDefaultAsync(x => x.Id == id);
//         }
//
//         public async Task<List<Tasks?>> Search(string name)
//         {
//             return await _context.Tasks
//                 .Where(x => x.Name.ToLower() == name.ToLower())
//                 .AsNoTracking()
//                 .ToListAsync();
//         }
//
//         public async Task<Tasks?> Get(Guid id, Guid userId)
//         {
//             return await _context.Tasks
//                 .AsNoTracking()
//                 .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
//
//         }
//
//         public async Task<bool> Remove(Guid id)
//         {
//             var query = await _context.Tasks
//                 .AsNoTracking()
//                 .FirstOrDefaultAsync(x => x.Id == id);
//
//             _context.Tasks.Remove(query);
//             _context.SaveChangesAsync();
//
//             return true;
//         }
//     }
// }