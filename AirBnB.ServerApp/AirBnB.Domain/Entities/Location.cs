using AirBnB.Domain.Common.Entities;

namespace AirBnB.Domain.Entities;

public class Location : IEntity
{
    public Guid Id { get; set; }
    
    public string ImageUrl { get; set; } = default!;
    
    public string Name { get; set; } = default!;
    
    public int BuiltYear { get; set; }
    
    public int PricePerNight { get; set; }
    
    public float FeedBack { get; set; }
    
    public Guid CategoryId { get; set; }
    
    public virtual LocationCategory? Category { get; set; }
}