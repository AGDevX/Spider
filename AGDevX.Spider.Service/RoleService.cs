using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AGDevX.Spider.Database.Contracts;
using AGDevX.Spider.Service.Contracts;
using AGDevX.Spider.Service.Models;
using AutoMapper;

namespace AGDevX.Spider.Service
{
    public sealed class RoleService : IRoleService
    {
        private readonly IMapper _autoMapper;
        private readonly IRoleRepository _roleRepository;

        public RoleService(IMapper autoMapper, IRoleRepository roleRepository)
        {
            _autoMapper = autoMapper;
            _roleRepository = roleRepository;
        }

        public async Task<Guid> AddRole(Role role)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Role>> GetRoles()
        {
            var dbRoles = await _roleRepository.GetRoles();
            var svcRoles = _autoMapper.Map<List<Role>>(dbRoles);
            return svcRoles;
        }

        public async Task UpdateRole(Role Role)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteRole(Guid? RoleId = default, string? code = default)
        {
            throw new NotImplementedException();
        }
    }
}