using Application.Dtos;
using AutoMapper;
using LogicalModels.UserAggregate.Entities;

namespace Application.Utility;

public sealed class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
    }
}
