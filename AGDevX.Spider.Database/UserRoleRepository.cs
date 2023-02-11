using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AGDevX.Database.Connections;
using AGDevX.Database.Dapper;
using AGDevX.Spider.Database.Models;

namespace AGDevX.Spider.Database.Contracts
{
    public sealed class UserRoleRepository : IUserRoleRepository
    {
        private readonly IDbConnectionProvider _dbConnectionProvider;

        public UserRoleRepository(IDbConnectionProvider dbConnectionProvider)
        {
            _dbConnectionProvider = dbConnectionProvider;
        }

        public Task<Guid>AddUserRole(Guid userId, Guid roleId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserRole>> GetUserRoles(Guid userId)
        {
            var args = new
            {
                userId
            };

            using (var conn = _dbConnectionProvider.GetOpenConnection())
            {
                var userRoles = (await conn.ExecuteSproc<UserRole>("[agdevx].GetUserRoles", args))?.ToList() ?? new List<UserRole>();
                return userRoles;
            }
        }

        public Task DeleteUserRole(Guid userId, Guid roleId)
        {
            throw new NotImplementedException();
        }
    }
}