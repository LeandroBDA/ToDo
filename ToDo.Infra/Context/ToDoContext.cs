using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;
using ToDo.Infra.Mappings;

namespace ToDo.Infra.Context
{
    public class ToDoContext : DbContext
    {
        public ToDoContext()
        {
        } 
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");
        }
    }
}



