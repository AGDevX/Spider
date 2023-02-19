using AutoMapper;
using Db = AGDevX.Spider.Database.Models;
using Svc = AGDevX.Spider.Service.Models;

namespace AGDevX.Spider.Service.AutoMapperProfiles
{
    public sealed class UserMappings : Profile
    {
        public UserMappings()
        {
            //-- From --> To
            CreateMap<Db.User, Svc.User>();

            CreateMap<Db.UserInfo.Person, Svc.UserInfo.Person>();
            CreateMap<Db.UserInfo.ExternalUserId, Svc.UserInfo.ExternalUserId>();
            CreateMap<Db.UserInfo.UserRole, Svc.UserInfo.UserRole>();
            CreateMap<Db.UserInfo, Svc.UserInfo>();

            //-- From --> To
            CreateMap<Svc.AddUser, Db.AddUser>();
        }
    }
}