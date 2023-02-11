using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AGDevX.Spider.Database.Contracts;
using AGDevX.Spider.Service.Models;
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

        public Task<Guid> AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetUser(Guid? userId = default, string? email = default)
        {
            var dbUser = await _userRepository.GetUser(userId, email);
            var svcUser = _autoMapper.Map<User>(dbUser);
            return svcUser;
        }

        public async Task<List<User>> GetUsers()
        {
            var dbUsers = await _userRepository.GetUsers();
            var svcUsers = _autoMapper.Map<List<User>>(dbUsers);
            return svcUsers;
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