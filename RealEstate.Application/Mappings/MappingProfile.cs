using AutoMapper;
using RealEstate.Application.DTOs;
using RealEstate.Domain;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RealEstate.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User
            CreateMap<User, UserDto>();
            CreateMap<RegisterUserDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());  

            // Property
            CreateMap<Property, PropertyDto>().ReverseMap();

            // Favourites
            CreateMap<Favorite, FavoriteDto>().ReverseMap();
        }
    }
}
