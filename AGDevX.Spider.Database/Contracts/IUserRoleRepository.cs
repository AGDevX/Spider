using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AGDevX.Spider.Database.Models;

namespace AGDevX.Spider.Database.Contracts
{
    public interface IUserRoleRepository
    {
        public Task<Guid>AddUserRole(Guid userId, Guid roleId);
        public Task<List<UserRole>> GetUserRoles(Guid userId);
        public Task DeleteUserRole(Guid userId, Guid roleId);
    }
}