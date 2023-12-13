using AirBnB.Api.Models.Dtos;
using AirBnB.Domain.Entities;
using AirBnB.Infrastructure.Extensions;
using AirBnB.Infrastructure.Settings;
using AutoMapper;
using Microsoft.Extensions.Options;

namespace AirBnB.Api.Common.Mappers;

// public class LocationCategoryMapper : Profile
// {
//     // public LocationCategoryMapper()
//     // {
//     //     CreateMap<LocationCategory, LocationCategoryDto>()
//     //         .ForMember(dest => dest, src => src.MapFrom(opt => opt.ImagePath.ToUrl()));
//     // }
// }