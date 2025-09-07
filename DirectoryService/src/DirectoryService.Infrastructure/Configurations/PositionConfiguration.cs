using DirectoryService.Domain.PositionEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Configurations;

public class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder
            .ToTable("positions")
            .HasKey(p => p.Id)
            .HasName("pk_position");
        builder.ComplexProperty(n => n.Name, nb =>
        {
            nb
                .Property(v => v.Value)
                .IsRequired()
                .HasMaxLength(Name.MAX_LENGTH)
                .HasColumnName("name");
        });
        builder
            .Property(d => d.Description)
            .IsRequired()
            .HasMaxLength(Position.DESCRIPTION_MAX_LENGTH)
            .HasColumnName("description");
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
    }
}