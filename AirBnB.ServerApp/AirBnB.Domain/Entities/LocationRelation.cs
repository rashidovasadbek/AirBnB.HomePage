namespace AirBnB.Domain.Entities;

public class LocationRelation
{
    public Guid LocationId { get; set; }
    
    public Guid LocationCategoryId { get; set; }
}