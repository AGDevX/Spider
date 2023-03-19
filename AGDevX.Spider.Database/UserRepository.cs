using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AGDevX.Database.Config;
using AGDevX.Database.Connections;
using AGDevX.Database.Dapper;
using AGDevX.Database.Exceptions;
using AGDevX.Guids;
using AGDevX.IEnumerables;
using AGDevX.Spider.Database.Models;
using AGDevX.Strings;
using Microsoft.Extensions.Logging;

namespace AGDevX.Spider.Database.Contracts;

public sealed class UserRepository : IUserRepository
{
    private readonly DatabaseConfig _databaseConfig;
    private readonly ILogger<UserRepository> _logger;
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public UserRepository(DatabaseConfig databaseConfig, ILogger<UserRepository> logger, IDbConnectionFactory dbConnectionFactory)
    {
        _databaseConfig = databaseConfig;
        _logger = logger;
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<Guid> AddUser(AddUser user)
    {
        //-- This isn't something normally baked into APIs. This is a shim so a database doesn't have to be hosted for this API.
        if (!_databaseConfig.UseDatabase)
        {
            return new Guid();
        }

        using (var conn = await _dbConnectionFactory.CreateAndOpenConnection(DatabaseProviderType.SqlServer))
        {
            var args = new
            {
                createdBy = user.CreatedBy,
                isActive = user.IsActive,
                firstName = user.FirstName,
                middleName = user.MiddleName,
                lastName = user.LastName,
                suffix = user.Suffix,
                email = user.Email,
                externalId = user.ExternalId,
                roleIds = user.RoleIds.ToIdDataTable()
            };

            var userId = (await conn.ExecuteSproc<Guid>("[agdevx].AddUser", args)).First();
            return userId;
        }
    }

    public async Task<User?> GetUser(Guid? userId = default, string? email = default)
    {
        //-- This isn't something normally baked into APIs. This is a shim so a database doesn't have to be hosted for this API.
        if (!_databaseConfig.UseDatabase)
        {
            return ReturnMockDataForGetUsers().FirstOrDefault();
        }

        if (userId.IsNullOrEmpty() && email.IsNullOrWhiteSpace())
        {
            throw new MissingSprocArgument("At least one argument must be provided");
        }

        var users = await GetUsers(userId, email);
        var user = users.FirstOrDefault();
        return user;
    }

    public async Task<List<User>> GetUsers()
    {
        return await GetUsers(null, null);
    }

    public async Task<UserInfo?> GetUserInfo(Guid? userId = default, string? externalUserId = default, string? email = default)
    {
        //-- This isn't something normally baked into APIs. This is a shim so a database doesn't have to be hosted for this API.
        if (!_databaseConfig.UseDatabase)
        {
            return ReturnMockDataForGetUserInfo().FirstOrDefault();
        }

        if (userId.IsNullOrEmpty() && externalUserId.IsNullOrWhiteSpace() && email.IsNullOrWhiteSpace())
        {
            throw new MissingSprocArgument("At least one argument must be provided");
        }

        var args = new
        {
            userId,
            externalUserId,
            email
        };

        using (var conn = await _dbConnectionFactory.CreateAndOpenConnection(DatabaseProviderType.SqlServer))
        using (var gridReader = await conn.QueryMultiple("[agdevx].GetUserInfo", args))
        {
            UserInfo? userInfo = default;

            try
            {
                var person = (await gridReader.ReadAsync<UserInfo.Person>()).First();
                userInfo = new UserInfo { User = person };

                var externalUserIds = (await gridReader.ReadAsync<UserInfo.ExternalUserId>()).ToList();
                userInfo.ExternalUserIds = externalUserIds;

                var roles = (await gridReader.ReadAsync<UserInfo.UserRole>()).ToList();
                userInfo.Roles = roles;

                return userInfo;
            }
            catch (InvalidOperationException ioex)
                when (ioex.Message.Contains("No columns were selected")) { return userInfo; }
        }
    }

    private async Task<List<User>> GetUsers(Guid? userId = default, string? email = default)
    {
        //-- This isn't something normally baked into APIs. This is a shim so a database doesn't have to be hosted for this API.
        if (!_databaseConfig.UseDatabase)
        {
            return ReturnMockDataForGetUsers();
        }

        using (var conn = await _dbConnectionFactory.CreateAndOpenConnection(DatabaseProviderType.SqlServer))
        {
            var args = new
            {
                userId,
                email
            };

            var users = (await conn.ExecuteSproc<User>("[agdevx].GetUsers", args))?.ToList() ?? new List<User>();
            return users;
        }
    }

    public Task UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUser(Guid? userId = default, string? email = default)
    {
        throw new NotImplementedException();
    }

    private List<User> ReturnMockDataForGetUsers()
    {
        return new List<User>
        {
            new User
            {
                Id = new Guid("FF939B25-D6AF-ED11-BA8D-8C85907AE767"),
                CreatedBy = new Guid("F3939B25-D6AF-ED11-BA8D-8C85907AE767"),
                CreatedAt = DateTime.UtcNow,
                ModifiedBy = new Guid("F3939B25-D6AF-ED11-BA8D-8C85907AE767"),
                ModifiedAt = DateTime.UtcNow,
                IsActive = true,
                FirstName = "Dave",
                LastName = "Lister",
                Suffix = "Sir",
                Email = "dave.lister@reddwarfjmcagdx.com",
            },
            new User
            {
                Id = new Guid("FF939B25-D6AF-ED11-BA8D-8C85907AE767"),
                CreatedBy = new Guid("F3939B25-D6AF-ED11-BA8D-8C85907AE767"),
                CreatedAt = DateTime.UtcNow,
                ModifiedBy = new Guid("F3939B25-D6AF-ED11-BA8D-8C85907AE767"),
                ModifiedAt = DateTime.UtcNow,
                IsActive = true,
                FirstName = "Arnold",
                MiddleName = "J",
                LastName = "Rimmer",
                Email = "arnold.rimmer@reddwarfjmcagdx.com",
            }
        };
    }

    private List<UserInfo> ReturnMockDataForGetUserInfo()
    {
        return new List<UserInfo>
        {
            new UserInfo
            {
                User = new UserInfo.Person
                {
                    Id = new Guid("F5939B25-D6AF-ED11-BA8D-8C85907AE767"),
                    IsActive = true,
                    FirstName = "Dave",
                    LastName = "Lister",
                    Suffix = "Sir",
                    Email = "dave.lister@reddwarfjmcagdx.com"
                },
                ExternalUserIds = new List<UserInfo.ExternalUserId>
                {
                    new UserInfo.ExternalUserId
                    {
                        Id = new Guid("FA939B25-D6AF-ED11-BA8D-8C85907AE767"),
                        IsActive = true,
                        UserId = new Guid("F5939B25-D6AF-ED11-BA8D-8C85907AE767"),
                        ExternalId = "EX_ID_DL_1"
                    }
                },
                Roles = new List<UserInfo.UserRole>
                {
                    new UserInfo.UserRole
                    {
                        UserId = new Guid("F5939B25-D6AF-ED11-BA8D-8C85907AE767"),
                        RoleId = new Guid("FE939B25-D6AF-ED11-BA8D-8C85907AE767"),
                        RoleIsActive = true,
                        RoleCode = "ADMIN",
                        RoleName = "Admin",
                        RoleDescription = "Administrator"
                    }
                }
            },
            new UserInfo
            {
                User = new UserInfo.Person
                {
                    Id = new Guid("F6939B25-D6AF-ED11-BA8D-8C85907AE767"),
                    IsActive = true,
                    FirstName = "Arnold",
                    MiddleName = "J",
                    LastName = "Rimmer",
                    Email = "arnold.rimmer@reddwarfjmcagdx.com",
                },
                ExternalUserIds = new List<UserInfo.ExternalUserId>
                {
                    new UserInfo.ExternalUserId
                    {
                        Id = new Guid("FB939B25-D6AF-ED11-BA8D-8C85907AE767"),
                        IsActive = true,
                        UserId = new Guid("F6939B25-D6AF-ED11-BA8D-8C85907AE767"),
                        ExternalId = "EX_ID_DL_1"
                    }
                },
                Roles = new List<UserInfo.UserRole>
                {
                    new UserInfo.UserRole
                    {
                        UserId = new Guid("F6939B25-D6AF-ED11-BA8D-8C85907AE767"),
                        RoleId = new Guid("FF939B25-D6AF-ED11-BA8D-8C85907AE767"),
                        RoleIsActive = true,
                        RoleCode = "NORMAL",
                        RoleName = "Normal",
                        RoleDescription = "Typical user access level"
                    }
                }
            }
        };
    }
}