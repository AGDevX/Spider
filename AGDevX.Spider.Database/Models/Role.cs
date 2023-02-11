using System;
using AGDevX.DateTimes;

namespace AGDevX.Spider.Database.Models
{
    public sealed class Role
    {
        public required Guid Id { get; set; }

        public required Guid CreatedBy { get; set; }

        private DateTime _createdAt;
        public required DateTime CreatedAt { get => _createdAt; set => _createdAt = value.SpecifyKind(DateTimeKind.Utc); }

        public required Guid ModifiedBy { get; set; }

        private DateTime _modifiedAt;
        public required DateTime ModifiedAt { get => _modifiedAt; set => _modifiedAt = value.SpecifyKind(DateTimeKind.Utc); }

        public required bool IsActive { get; set; }
        public required string Name { get; set; }
        public required string Code { get; set; }
        public required string Description { get; set; }
    }
}