using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AGDevX.Database.Config;
using AGDevX.Database.Connections;
using AGDevX.Database.Dapper;
using AGDevX.Spider.Database.Models;
using Microsoft.Extensions.Logging;

namespace AGDevX.Spider.Database.Contracts;

public sealed class RoleRepository : IRoleRepository
{
    private readonly DatabaseConfig _databaseConfig;
    private readonly ILogger<UserRepository> _logger;
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public RoleRepository(DatabaseConfig databaseConfig, ILogger<UserRepository> logger, IDbConnectionFactory dbConnectionFactory)
    {
        _databaseConfig = databaseConfig;
        _logger = logger;
        _dbConnectionFactory = dbConnectionFactory;
    }

    public Task<Guid> AddRole(Role role)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Role>> GetRoles()
    {
        //-- This isn't something normally baked into APIs. This is a shim so a database doesn't have to be hosted for this API.
        if (!_databaseConfig.UseDatabase)
        {
            return ReturnMockDataForGet();
        }

        using (var conn = await _dbConnectionFactory.CreateAndOpenConnection(DatabaseProviderType.SqlServer))
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

    private List<Role> ReturnMockDataForGet()
    {
        return new List<Role>
        {
            new Role
            {
                Id = new Guid("FF939B25-D6AF-ED11-BA8D-8C85907AE767"),
                CreatedBy = new Guid("F3939B25-D6AF-ED11-BA8D-8C85907AE767"),
                CreatedAt = DateTime.UtcNow,
                ModifiedBy = new Guid("F3939B25-D6AF-ED11-BA8D-8C85907AE767"),
                ModifiedAt = DateTime.UtcNow,
                IsActive = true,
                IsDefault = false,
                Name = "Admin",
                Code = "ADMIN",
                Description = "Administrator"
            },
            new Role
            {
                Id = new Guid("FF939B25-D6AF-ED11-BA8D-8C85907AE767"),
                CreatedBy = new Guid("F3939B25-D6AF-ED11-BA8D-8C85907AE767"),
                CreatedAt = DateTime.UtcNow,
                ModifiedBy = new Guid("F3939B25-D6AF-ED11-BA8D-8C85907AE767"),
                ModifiedAt = DateTime.UtcNow,
                IsActive = true,
                IsDefault = false,
                Name = "Normal",
                Code = "NORMAL",
                Description = "Typical user access level"
            }
        };
    }
}