using AirBnB.Api.Models.Dtos;
using AirBnB.Application.Services;
using AirBnB.Domain.Common.Query;
using AirBnB.Domain.Entities;
using AirBnB.Infrastructure.Extensions;
using AirBnB.Infrastructure.Settings;
using AirBnB.Persistence.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AirBnB.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class LocationCategoriesController(ILocationCategoryService  locationCategoryService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> GetLocationCategoryService(
        [FromQuery] FilterPagination filterPagination,
        [FromServices] IOptions<ApiSettings> apiSettings,
        CancellationToken cancellationToken = default)
    {
        var querySpecification =
            new QuerySpecification<LocationCategory>(filterPagination.PageSize, filterPagination.PageToken);
        var result = await locationCategoryService.GetAsync(querySpecification, cancellationToken: cancellationToken);
        var locationCategories = result.Select(locationCategory => new LocationCategoryDto
        {
            Id = locationCategory.Id,
            Name = locationCategory.Name,
            ImagePath = locationCategory.ImagePath.ToUrl(apiSettings.Value.ApiUrl),
        });
        
        return locationCategories.Any() ? Ok(locationCategories) : BadRequest();
    }
}