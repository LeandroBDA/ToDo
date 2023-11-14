using ToDo.Infra.Context;
using ToDo.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entites;
using ToDo.Domain.Validators;
namespace ToDo.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        private readonly ToDoContext _context;
        private IBaseRepository<T> _baseRepositoryImplementation;

        public BaseRepository(ToDoContext context)
        {
            _context = context;
        }

        public virtual async Task<T> Create(T obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        async Task<T> IBaseRepository<T>.Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task Remove(int id)
        {
            Tasks? tasks = await GetById(id);

            if ( tasks != null)
            {
                _context.Remove(tasks);
                await _context.SaveChangesAsync();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Não existem Tasks no momento");
                Thread.Sleep(5000);
                Console.Clear();
            }
        }
        public virtual async Task<Tasks?> GetById(int id) 
        {
            var Task = await _context.Set<T>()
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ToListAsync();

            return Task.FirstOrDefault();
        }

        public virtual async Task<List<T>> Search()
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

