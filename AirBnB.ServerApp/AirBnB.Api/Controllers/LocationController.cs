using AirBnB.Api.Models.Dtos;
using AirBnB.Application.Locations.Models;
using AirBnB.Application.Services;
using AirBnB.Infrastructure.Extensions;
using AirBnB.Infrastructure.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AirBnB.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationsController(ILocationService locationService) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> GetLocations(
        [FromQuery] LocationFilter locationFilter,
        [FromServices]  IOptions<ApiSettings> apiSettings,
        CancellationToken cancellationToken = default)
    {
        var result = await locationService.GetAsync(locationFilter.ToQuerySpecification(), cancellationToken: cancellationToken);
        var locations = result.Select(location => new LocationDto
        {
            Id = location.Id,
            ImageUrl = location.ImageUrl,
            Name = location.Name,
            BuiltYear = location.BuiltYear,
            PricePerNight = location.PricePerNight,
            FeedBack = location.FeedBack
        });
        return locations.Any() ? Ok(locations) : NoContent();
    }
}