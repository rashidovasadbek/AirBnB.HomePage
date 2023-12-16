using AirBnB.Domain.Common.Entities;

namespace AirBnB.Domain.Entities;

public  class LocationCategory : IEntity
{
    public Guid Id { get; set; }
    
    public string Name { get; init; } = default!;

    public string ImagePath { get; init; } = default!;
    public virtual List<Location> Locations { get; } = new();
}