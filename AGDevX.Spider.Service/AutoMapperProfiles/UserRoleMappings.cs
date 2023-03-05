using AutoMapper;
using Db = AGDevX.Spider.Database.Models;
using Svc = AGDevX.Spider.Service.Models;

namespace AGDevX.Spider.Service.AutoMapperProfiles;

public sealed class UserRoleMappings : Profile
{
    public UserRoleMappings()
    {
        //-- Database --> Service
        CreateMap<Db.UserRole, Svc.UserRole>().ReverseMap();
    }
}