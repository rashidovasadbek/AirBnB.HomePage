namespace AirBnB.Api.Models.Dtos;

public class LocationCategoryDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = default!;

    public string ImagePath { get; set; } = default!;
}