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

        public Task<Tasks?> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> Remove(int id)
        {
            var obj = await GetById(id);

            if (obj != null)
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            else
            {
                return obj;
            }
        } 
        public virtual async Task<T?> GetById(int id) 
        {
            var obj = await _context.Set<T>()
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ToListAsync();

            return obj.FirstOrDefault();
        }

        public virtual async Task<List<T>> Search()
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

