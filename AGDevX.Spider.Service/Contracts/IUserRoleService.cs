using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AGDevX.Spider.Service.Models;

namespace AGDevX.Spider.Service.Contracts;

public interface IUserRoleService
{
    public Task<Guid> AddUserRole(Guid userId, Guid roleId);
    public Task<List<UserRole>> GetUserRoles(Guid userId);
    public Task DeleteUserRole(Guid userId, Guid roleId);
}