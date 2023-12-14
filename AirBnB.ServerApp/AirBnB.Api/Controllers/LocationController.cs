using AirBnB.Application.Services;
using AirBnB.Domain.Common.Query;
using AirBnB.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AirBnB.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
    private readonly ILocationService _locationService;

    public LocationController(ILocationService locationService)
    {
        _locationService = locationService;
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetLocations(
        [FromQuery] FilterPagination paginationOptions,
        [FromServices] ILocationService locationService,
        CancellationToken cancellationToken = default)
    {
        var specificationA = new QuerySpecification<Location>(paginationOptions.PageSize, paginationOptions.PageToken);
        var result = await locationService.GetByFilterAsync(specificationA, cancellationToken: cancellationToken);
        return result.Any() ? Ok(result) : BadRequest();
    }
    
    
}