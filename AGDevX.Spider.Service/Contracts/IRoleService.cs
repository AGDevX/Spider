using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AGDevX.Spider.Service.Models;

namespace AGDevX.Spider.Service.Contracts;

public interface IRoleService
{
    public Task<Guid> AddRole(Role role);
    public Task<List<Role>> GetRoles();
    public Task UpdateRole(Role Role);
    public Task DeleteRole(Guid? RoleId = default, string? code = default);
}