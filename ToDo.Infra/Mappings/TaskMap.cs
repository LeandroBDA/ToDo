using FluentValidation;
using Manager.Domain.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ToDo.Infra.Mappings
{
    public class TaskMap : IEntityTypeConfiguration<Tasks>
    {
        public void Configure(EntityTypeBuilder<Tasks> builder)
        {
            builder.ToTable("Task");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("VARCHAR(30)");
            
            builder.Property(x => x.UserId)
                .IsRequired()
                .HasColumnName("UserId")
                .HasColumnType("VARCHAR(30)");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("Name")
                .HasColumnType("VARCHAR(30)");

            builder.Property(x => x.Description)
                .HasMaxLength(300)
                .HasColumnName("Description")
                .HasColumnType("VARCHAR(300)");

            builder.Property(x => x.ConcludedAt)
                .HasColumnName("concludedAt")
                .HasColumnType("DATETIME");

            builder.Property(x => x.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasColumnType("DATETIME");

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .HasColumnType("DATETIME");


        }
    }
}

