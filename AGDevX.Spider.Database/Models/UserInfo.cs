using System;
using System.Collections.Generic;
using AGDevX.DateTimes;

namespace AGDevX.Spider.Database.Models
{
    public sealed class UserInfo
    {
        public required Person User { get; set; }
        public List<ExternalUserId> ExternalUserIds { get; set; } = new List<ExternalUserId>();
        public List<UserRole> Roles { get; set; } = new List<UserRole>();

        public sealed class Person
        {
            public required Guid Id { get; set; }
            public required bool IsActive { get; set; }
            public required string Email { get; set; }
            public required string FirstName { get; set; }
            public string? MiddleName { get; set; }
            public required string LastName { get; set; }
            public string? Suffix { get; set; }
        }

        public sealed class ExternalUserId
        {
            public required Guid Id { get; set; }
            public required bool IsActive { get; set; }
            public required Guid UserId { get; set; }
            public required string ExternalId { get; set; }
        }

        public sealed class UserRole
        {
            public required Guid UserId { get; set; }
            public required Guid RoleId { get; set; }
            public required string RoleName { get; set; }
            public required string RoleCode { get; set; }
            public required string RoleDescription { get; set; }
            public required bool RoleIsActive { get; set; }
        }
    }
}