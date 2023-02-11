using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AGDevX.Spider.Database.Contracts;
using AGDevX.Spider.Service.Models;
using AutoMapper;

namespace AGDevX.Spider.Service.Contracts
{
    public sealed class UserRoleService : IUserRoleService
    {
        private readonly IMapper _autoMapper;
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleService(IMapper autoMapper, IUserRoleRepository userRoleRepository)
        {
            _autoMapper = autoMapper;
            _userRoleRepository = userRoleRepository;
        }

        public Task<Guid> AddUserRole(Guid userId, Guid roleId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserRole>> GetUserRoles(Guid userId)
        {
            var dbUserRoles = await _userRoleRepository.GetUserRoles(userId);
            var svcUserRoles = _autoMapper.Map<List<UserRole>>(dbUserRoles);
            return svcUserRoles;
        }

        public Task DeleteUserRole(Guid userId, Guid roleId)
        {
            throw new NotImplementedException();
        }
    }
}