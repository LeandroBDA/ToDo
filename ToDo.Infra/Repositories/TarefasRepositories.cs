using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;
using ToDo.Infra.Context;
using ToDo.Infra.Interfaces;

namespace ToDo.Infra.Repositories
{
    public class TarefasRepositories : BaseRepositories<Tarefas>, ITarefasRepository
    {
        private readonly ToDoContext _context;

        public TarefasRepositories(ToDoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Tarefas> GetByEmail(string email)
        {
            var tarefas = await _context.Tarefas.Where
                    (x => x.Email.ToLower() == email.ToLower())
                .AsNoTracking()
                .ToListAsync();

            return tarefas.FirstOrDefault();
        }

        public async Task<bool> Remove(int id)
        {
            await using var context = new ToDoContext();
            var obj = await _context.Set<Tarefas>().SingleOrDefaultAsync(x => x.Id == id);

            if (obj == null) return false;
            _context.Remove(obj);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<List<Tarefas>> SearchByEmail(string email)
        {
            var allUsers = await _context.Tarefas.Where
                    (x => x.Email.ToLower().Contains(email.ToLower()))
                .AsNoTracking()
                .ToListAsync();

            return allUsers;
        }

        public async Task<List<Tarefas>> BuscarNome(string name)
        {
            var allUsers = await _context.Tarefas.Where
                    (x => x.Email.ToLower().Contains(name.ToLower()))
                .AsNoTracking()
                .ToListAsync();

            return allUsers;
        }
    }
}

