using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AGDevX.Database.Connections;
using AGDevX.Database.Dapper;
using AGDevX.Guids;
using AGDevX.Spider.Database.Models;
using AGDevX.Strings;

namespace AGDevX.Spider.Database.Contracts
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly IDbConnectionProvider _dbConnectionProvider;

        public UserRepository(IDbConnectionProvider dbConnectionProvider)
        {
            _dbConnectionProvider = dbConnectionProvider;
        }

        public Task<Guid> AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetUser(Guid? userId = default, string? email = default)
        {
            if (userId.IsNullOrEmpty() && email.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("At least one argument must be provided.");
            }

            var users = await GetUsers(userId, email);
            var user = users.FirstOrDefault();
            return user;
        }

        public async Task<List<User>> GetUsers()
        {
            return await GetUsers(null, null);
        }

        private async Task<List<User>> GetUsers(Guid? userId = default, string? email = default)
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