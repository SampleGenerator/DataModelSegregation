using AutoMapper;
using DataModels.UserAggregate;
using LogicalModels.UserAggregate.Entities;

namespace ApplicationServices.Utility;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserData>();
        CreateMap<UserData, User>();
    }
}
