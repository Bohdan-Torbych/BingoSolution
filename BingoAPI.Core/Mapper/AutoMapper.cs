using AutoMapper;
using BingoAPI.Core.Dtos;
using BingoAPI.Core.Entities;

namespace BingoAPI.Core.Mapper;

/// <summary>
/// Represents an AutoMapper profile for mapping between different types.
/// </summary>
public class AutoMapper : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AutoMapper"/> class.
    /// </summary>
    public AutoMapper()
    {
        CreateMap<ApplicationUser, UserResponse>();

        CreateMap<RegisterDto, ApplicationUser>()
            .ForMember(dest => dest.UserName, option => option.MapFrom(src => src.Email))
            .ForMember(dest => dest.Email, option => option.MapFrom(src => src.Email))
            .ForMember(dest => dest.FullName, option => option.MapFrom(src => src.FullName));
    }
}


