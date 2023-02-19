using AutoMapper;
using Api = AGDevX.Spider.WebApi.Models;
using Svc = AGDevX.Spider.Service.Models;

namespace AGDevX.Spider.Service.AutoMapperProfiles
{
    public sealed class UserMappings : Profile
    {
        public UserMappings()
        {
            //-- From --> To
            CreateMap<Svc.User, Api.User>();

            CreateMap<Svc.UserInfo.Person, Api.UserInfo.Person>();
            CreateMap<Svc.UserInfo.ExternalUserId, Api.UserInfo.ExternalUserId>();
            CreateMap<Svc.UserInfo.UserRole, Api.UserInfo.UserRole>();
            CreateMap<Svc.UserInfo, Api.UserInfo>();

            //-- From --> To
            CreateMap<Api.AddUser, Svc.AddUser>();
        }
    }
}