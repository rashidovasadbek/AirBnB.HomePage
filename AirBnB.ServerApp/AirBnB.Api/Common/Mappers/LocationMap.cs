using AirBnB.Api.Models.Dtos;
using AirBnB.Domain.Entities;
using AutoMapper;

namespace AirBnB.Api.Common.Mappers;

public class LocationMap : Profile
{
    public LocationMap()
    {
        CreateMap<Location, LocationDto>();
    }
}