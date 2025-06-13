using AutoMapper;
using RealEstateCam.Application.Owners.DTOs;
using RealEstateCam.Domain.Entities.Owners;

namespace RealEstateCam.Application.Mappings
{
    public class OwnerMappingProfile : Profile
    {
        public OwnerMappingProfile() 
        {
            CreateMap<Owner, OwnerDto>().ReverseMap();
        }
    }
}
