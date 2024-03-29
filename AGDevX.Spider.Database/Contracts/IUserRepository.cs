﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AGDevX.Spider.Database.Models;

namespace AGDevX.Spider.Database.Contracts;

public interface IUserRepository
{
    public Task<Guid>AddUser(AddUser user);
    public Task<User?> GetUser(Guid? userId = default, string? email = default);
    public Task<List<User>> GetUsers();
    public Task<UserInfo?> GetUserInfo(Guid? userId = default, string? externalUserId = default, string? email = default);
    public Task UpdateUser(User user);
    public Task DeleteUser(Guid? userId = default, string? email = default);
}