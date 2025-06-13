using AutoMapper;
using RealEstateCam.Application.Properties.DTOs;
using RealEstateCam.Application.PropertyImages.DTOs;
using RealEstateCam.Application.PropertyTraces.DTOs;
using RealEstateCam.Domain.Entities.Properties;

namespace RealEstateCam.Application.Mappings
{
    public class PropertyMappingProfile : Profile
    {
        public PropertyMappingProfile()
        {
            CreateMap<Property, PropertyDto>();

            CreateMap<PropertyImage, PropertyImageDto>();

            CreateMap<PropertyTrace, PropertyTraceDto>();
        }
    }
}
