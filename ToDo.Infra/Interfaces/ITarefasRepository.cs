using ToDo.Domain.Entities;

namespace ToDo.Infra.Interfaces
{
    public interface ITarefasRepository : IBaseRepository<Tarefas>
    {
        Task<Tarefas> GetByEmail(string email);

        Task<bool> Remove(int id);
        Task<List<Tarefas>> SearchByEmail(string email);

        Task<List<Tarefas>> BuscarNome(string name);
    }
}

