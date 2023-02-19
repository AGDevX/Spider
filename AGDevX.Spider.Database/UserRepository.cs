using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AGDevX.Database.Connections;
using AGDevX.Database.Dapper;
using AGDevX.Database.Exceptions;
using AGDevX.Guids;
using AGDevX.IEnumerables;
using AGDevX.Spider.Database.Models;
using AGDevX.Strings;
using Microsoft.Extensions.Logging;

namespace AGDevX.Spider.Database.Contracts
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly ILogger<UserRepository> _logger;
        private readonly IDbConnectionProvider _dbConnectionProvider;

        public UserRepository(ILogger<UserRepository> logger, IDbConnectionProvider dbConnectionProvider)
        {
            _logger = logger;
            _dbConnectionProvider = dbConnectionProvider;
        }

        public async Task<Guid> AddUser(AddUser user)
        {
            try
            {
                using (var conn = _dbConnectionProvider.GetOpenConnection())
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
            catch (SqlException sqlEx)
            {
                _logger.LogError(sqlEx,sqlEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<User?> GetUser(Guid? userId = default, string? email = default)
        {
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
            if (userId.IsNullOrEmpty() && externalUserId.IsNullOrWhiteSpace() && email.IsNullOrWhiteSpace())
            {
                throw new MissingSprocArgument("At least one argument must be provided");
            }

            try
            {
                var args = new
                {
                    userId,
                    externalUserId,
                    email
                };

                using (var conn = _dbConnectionProvider.GetOpenConnection())
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
            catch (SqlException sqlEx)
            {
                _logger.LogError(sqlEx, sqlEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        private async Task<List<User>> GetUsers(Guid? userId = default, string? email = default)
        {
            try
            {
                using (var conn = _dbConnectionProvider.GetOpenConnection())
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
            catch (SqlException sqlEx)
            {
                _logger.LogError(sqlEx, sqlEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
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
    }
}