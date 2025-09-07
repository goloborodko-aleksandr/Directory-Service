using CSharpFunctionalExtensions;
using DirectoryService.Domain.LocationEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder
            .ToTable("locations")
            .HasKey(l => l.Id)
            .HasName("pk_location");
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
            .ComplexProperty(a => a.Address, ab =>
            {
                ab
                    .Property(c => c.Country)
                    .IsRequired()
                    .HasColumnName("country");
                ab
                    .Property(r => r.Region)
                    .IsRequired()
                    .HasColumnName("region");
                ab
                    .Property(c => c.City)
                    .IsRequired()
                    .HasColumnName("city");
                ab
                    .Property(d => d.District)
                    .IsRequired(false)
                    .HasColumnName("district");
                ab
                    .Property(s => s.Street)
                    .IsRequired()
                    .HasColumnName("street");
                ab
                    .Property(h => h.HouseNumber)
                    .IsRequired(false)
                    .HasColumnName("house_number");
                ab
                    .Property(b => b.Building)
                    .IsRequired(false)
                    .HasColumnName("building");
                ab
                    .Property(a => a.Apartment)
                    .IsRequired(false)
                    .HasColumnName("apartment");
                ab
                    .Property(z => z.ZipCode)
                    .IsRequired(false)
                    .HasColumnName("zip_code");
                ab
                    .Property(a => a.AdditionalInfo)
                    .IsRequired(false)
                    .HasColumnName("additional_info");
            });
        builder
            .ComplexProperty(t => t.Timezone, tb =>
            {
                tb
                    .Property(v => v.Value)
                    .IsRequired()
                    .HasColumnName("timezone");
            });
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