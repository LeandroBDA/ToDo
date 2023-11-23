using ToDo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ToDo.Infra.Mappings;
public class TarefasMap : IEntityTypeConfiguration<Tarefas>
{
    public void Configure(EntityTypeBuilder<Tarefas> builder)
    {
        builder.ToTable("Tarefas");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .UseMySqlIdentityColumn()
            .HasColumnType("BIGINT");
            
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(80)
            .HasColumnName("name")
            .HasColumnType("VARCHAR(80)");

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("password")
            .HasColumnType("VARCHAR(200)");
    }
}