using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AGDevX.Database.Connections;
using AGDevX.Database.Dapper;
using AGDevX.Spider.Database.Models;
using Microsoft.Extensions.Logging;

namespace AGDevX.Spider.Database.Contracts
{
    public sealed class RoleRepository : IRoleRepository
    {
        private readonly ILogger<UserRepository> _logger;
        private readonly IDbConnectionProvider _dbConnectionProvider;

        public RoleRepository(ILogger<UserRepository> logger, IDbConnectionProvider dbConnectionProvider)
        {
            _logger = logger;
            _dbConnectionProvider = dbConnectionProvider;
        }

        public Task<Guid> AddRole(Role role)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Role>> GetRoles()
        {
            using (var conn = _dbConnectionProvider.GetOpenConnection())
            {
                var roles = (await conn.ExecuteSproc<Role>("[agdevx].GetRoles"))?.ToList() ?? new List<Role>();
                return roles;
            }
        }

        public Task UpdateRole(Role Role)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRole(Guid? RoleId = default, string? code = default)
        {
            throw new NotImplementedException();
        }
    }
}