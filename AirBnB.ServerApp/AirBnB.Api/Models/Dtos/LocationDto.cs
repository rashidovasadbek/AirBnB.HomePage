namespace AirBnB.Api.Models.Dtos;

public class LocationDto
{
    
    public string ImageUrl { get; set; } = default!;
    
    public string Name { get; set; } = default!;
    
    public int BuiltYear { get; set; }
    
    public int PricePerNight { get; set; }
    
    public float FeedBack { get; set; }
    
}