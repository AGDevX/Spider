using System;
using AGDevX.DateTimes;

namespace AGDevX.Spider.Web.Api.Models
{
    public sealed class GetUserResponse
    {
        public Guid Id { get; set; }

        public Guid CreatedBy { get; set; }

        private DateTime _createdAt;
        public DateTime CreatedAt { get => _createdAt; set => _createdAt = value.SpecifyKind(DateTimeKind.Utc); }

        public Guid ModifiedBy { get; set; }

        private DateTime _modifiedAt;
        public DateTime ModifiedAt { get => _modifiedAt; set => _modifiedAt = value.SpecifyKind(DateTimeKind.Utc); }

        public bool IsActive { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
    }
}