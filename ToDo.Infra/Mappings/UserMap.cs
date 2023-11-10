using ToDo.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;

namespace ToDo.Infra.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("VARCHAR()");

            builder.Property(x => x.Role)
                .HasColumnName("Roles")
                .HasColumnType("VARCHAR(15)");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("Name")
                .HasColumnType("VARCHAR(80)");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(90)
                .HasColumnName("Email")
                .HasColumnType("VARCHAR(90)");

            builder.Property(x => x.Password)
                .IsRequired()
                .HasColumnName("PassWord")
                .HasColumnType("VARCHAR(60)");

            builder
                .HasMany(x => x.Tasks)
                .WithOne(p => p.User)
                .OnDelete(DeleteBehavior.Restrict); //so consigo apagar um usario se ele nao tiver mais tarefas
        }
    }
}

