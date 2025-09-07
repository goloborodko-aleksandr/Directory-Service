using DirectoryService.Domain.ConnectionEntity;
using DirectoryService.Domain.DepartmentEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder
            .ToTable("departments")
            .HasKey(d => d.Id)
            .HasName("pk_department");
        builder
            .ComplexProperty(n => n.Name, nb =>
        {
            nb
                .Property(v => v.Value)
                .IsRequired()
                .HasMaxLength(Name.MAX_LENGTH)
                .HasColumnName("name");
        });
        builder
            .ComplexProperty(i => i.Identifier, ib =>
        {
            ib
                .Property(v => v.Value)
                .IsRequired()
                .HasMaxLength(Identifier.MAX_LENGTH)
                .HasColumnName("identifier");
        });
        builder
            .ComplexProperty(p => p.Path, pb =>
        {
            pb
                .Property(v => v.Value)
                .IsRequired()
                .HasColumnName("path");
        });
        builder
            .Property(p => p.ParentId)
            .IsRequired(false)
            .HasColumnName("parent_id");
        builder
            .Property(d => d.Depth)
            .IsRequired()
            .HasColumnName("depth");
        builder
            .Property(d => d.IsActive)
            .IsRequired()
            .HasColumnName("is_active");
        builder
            .Property(c => c.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");
        builder
            .Property(c => c.UpdatedAt)
            .IsRequired()
            .HasColumnName("updated_at");
        builder
            .HasOne<Department>()
            .WithMany(ch => ch.Children)
            .IsRequired()
            .HasForeignKey(ch => ch.ParentId);
    }
}