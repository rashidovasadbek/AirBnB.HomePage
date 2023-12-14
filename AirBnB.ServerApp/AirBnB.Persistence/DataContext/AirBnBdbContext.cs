using AirBnB.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirBnB.Persistence.DataContext;

public class AirBnBdbContext : DbContext
{
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<LocationCategory> LocationCategories => Set<LocationCategory>();

    public DbSet<LocationRelation> LocationRelations => Set<LocationRelation>();

    public AirBnBdbContext(DbContextOptions<AirBnBdbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AirBnBdbContext).Assembly);
    }
}