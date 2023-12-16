using AirBnB.Domain.Common.Entities;

namespace AirBnB.Domain.Entities;

public class Location : IEntity
{
    public Guid Id { get; set; }
    
    public string ImageUrl { get; init; } = default!;
    
    public string Name { get; init; } = default!;
    
    public int BuiltYear { get; init; }
    
    public int PricePerNight { get; init; }
    
    public float FeedBack { get; init; }
    
    public Guid CategoryId { get; init; }
    
    public virtual LocationCategory? Category { get; init; }
}