using DirectoryService.Domain.ConnectionEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Configurations;

public class DepartmentLocationConfiguration: IEntityTypeConfiguration<DepartmentLocation>
{
    public void Configure(EntityTypeBuilder<DepartmentLocation> builder)
    {
        builder
            .HasKey(dl => dl.Id)
            .HasName("pk_department_location");
        builder
            .HasOne(dl => dl.Department)
            .WithMany(d => d.DepartmentLocations)
            .HasForeignKey("department_id");
        builder
            .HasOne(d => d.Location)
            .WithMany(l => l.DepartmentLocations)
            .HasForeignKey("location_id");
    }
}