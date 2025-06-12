using AutoMapper;
using RealEstateCam.Application.Users.DTOs;
using RealEstateCam.Domain.Entities.Users;

namespace RealEstateCam.Application.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile() 
        {
            CreateMap<User, UserDto>();

            CreateMap<(User user, string token), LoginDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.user))
                .ForMember(dest => dest.Token, opt => opt.MapFrom(src => src.token));
        }
    }
}
