using AirBnB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirBnB.Persistence.EntityConfigurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.Property(template => template.Name).IsRequired().HasMaxLength(256);
        builder.Property(template => template.ImageUrl).IsRequired().HasMaxLength(256);
        builder.Property(template => template.BuiltYear).IsRequired();
        builder.Property(template => template.FeedBack).IsRequired();
        builder.Property(template => template.PricePerNight).IsRequired();

        builder.HasMany(location => location.LocationCategories)
            .WithMany(locationCategory => locationCategory.Locations)
            .UsingEntity<LocationRelation>();
    }
}