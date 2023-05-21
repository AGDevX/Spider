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

public sealed class UserRoleRepository : IUserRoleRepository
{
    private readonly DatabaseConfig _databaseConfig;
    private readonly ILogger<UserRepository> _logger;
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public UserRoleRepository(DatabaseConfig databaseConfig, ILogger<UserRepository> logger, IDbConnectionFactory dbConnectionFactory)
    {
        _databaseConfig = databaseConfig;
        _logger = logger;
        _dbConnectionFactory = dbConnectionFactory;
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

        using (var conn = await _dbConnectionFactory.CreateAndOpenConnection(DatabaseProviderType.SqlServer))
        {
            var userRoles = (await conn.ExecuteSproc<UserRole>("[agdevx].GetUserRoles", args))?.ToList() ?? new List<UserRole>();
            return userRoles;
        }
    }

    public Task DeleteUserRole(Guid userId, Guid roleId)
    {
        throw new NotImplementedException();
    }
    private List<UserRole> ReturnMockDataForGetUserRoles()
    {
        return new List<UserRole>
        {
            new UserRole
            {
                Id = new Guid("04949B25-D6AF-ED11-BA8D-8C85907AE767"),
                CreatedBy = new Guid("F3939B25-D6AF-ED11-BA8D-8C85907AE767"),
                CreatedAt = DateTime.UtcNow,
                UserId = new Guid("F5939B25-D6AF-ED11-BA8D-8C85907AE767"),
                RoleId = new Guid("FE939B25-D6AF-ED11-BA8D-8C85907AE767")
            },
            new UserRole
            {
                Id = new Guid("04949B25-D6AF-ED11-BA8D-8C85907AE767"),
                CreatedBy = new Guid("F3939B25-D6AF-ED11-BA8D-8C85907AE767"),
                CreatedAt = DateTime.UtcNow,
                UserId = new Guid("F6939B25-D6AF-ED11-BA8D-8C85907AE767"),
                RoleId = new Guid("FF939B25-D6AF-ED11-BA8D-8C85907AE767")
            }
        };
    }
}