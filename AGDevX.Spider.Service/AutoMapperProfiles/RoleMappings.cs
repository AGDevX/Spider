using AutoMapper;
using Db = AGDevX.Spider.Database.Models;
using Svc = AGDevX.Spider.Service.Models;

namespace AGDevX.Spider.Service.AutoMapperProfiles;

public sealed class RoleMappings : Profile
{
    public RoleMappings()
    {
        //-- Database --> Service
        CreateMap<Db.Role, Svc.Role>().ReverseMap();
    }
}