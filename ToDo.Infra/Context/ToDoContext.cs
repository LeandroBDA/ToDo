using ToDo.Domain.Entities;
using ToDo.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ToDo.Infra.Context;

public class ToDoContext : DbContext
{
    public ToDoContext() {}
    
    public ToDoContext(DbContextOptions options) : base(options) {}

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Tarefas> Tarefas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new TarefasMap());
    }
}