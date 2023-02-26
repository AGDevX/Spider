using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AGDevX.Guids;
using AGDevX.Spider.Database.Contracts;
using AGDevX.Spider.Service.Models;
using AGDevX.Strings;
using AutoMapper;

namespace AGDevX.Spider.Service.Contracts
{
    public sealed class UserService : IUserService
    {
        private readonly IMapper _autoMapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper autoMapper, IUserRepository userRepository)
        {
            _autoMapper = autoMapper;
            _userRepository = userRepository;
        }

        public async Task<Guid> AddUser(AddUser user)
        {
            var dbUser = _autoMapper.Map<Database.Models.AddUser>(user);
            var userId = await _userRepository.AddUser(dbUser);
            return userId;
        }

        public async Task<User?> GetUser(Guid? userId = default, string? email = default)
        {
            var dbUser = await _userRepository.GetUser(userId, email);
            var svcUser = _autoMapper.Map<User>(dbUser);
            return svcUser;
        }

        public async Task<List<User>> GetUsers(Guid? userId = default, string? email = default)
        {
            var svcUsers = new List<User>();

            if (userId.IsNullOrEmpty() && email.IsNullOrWhiteSpace())
            {
                var dbUsers = await _userRepository.GetUsers();
                svcUsers.AddRange(_autoMapper.Map<List<User>>(dbUsers));
            }
            else
            {
                var svcUser = await GetUser(userId, email);
                if (svcUser != null)
                {
                    svcUsers.Add(svcUser);
                }
            }

            return svcUsers;
        }

        public async Task<UserInfo?> GetUserInfo(Guid? userId = default, string? externalUserId = default, string? email = default)
        {
            var dbUserInfo = await _userRepository.GetUserInfo(userId, externalUserId, email);
            var svcUserInfo = _autoMapper.Map<UserInfo>(dbUserInfo);
            return svcUserInfo;
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