using System;
using AGDevX.DateTimes;

namespace AGDevX.Spider.Web.Api.Models
{
    public sealed class User
    {
        public required Guid Id { get; set; }

        public required Guid CreatedBy { get; set; }

        private DateTime _createdAt;
        public required DateTime CreatedAt { get => _createdAt; set => _createdAt = value.SpecifyKind(DateTimeKind.Utc); }

        public required Guid ModifiedBy { get; set; }

        private DateTime _modifiedAt;
        public required DateTime ModifiedAt { get => _modifiedAt; set => _modifiedAt = value.SpecifyKind(DateTimeKind.Utc); }

        public required bool IsActive { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public string? Suffix { get; set; }
        public required string Email { get; set; }
    }
}