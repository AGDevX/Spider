using System;
using AGDevX.DateTimes;

namespace AGDevX.Spider.Service.Models;

public sealed class UserRole
{
    public required Guid Id { get; set; }

    public required Guid CreatedBy { get; set; }

    private DateTime _createdAt;
    public required DateTime CreatedAt { get => _createdAt; set => _createdAt = value.SpecifyKind(DateTimeKind.Utc); }

    public required Guid UserId { get; set; }
    public required Guid RoleId { get; set; }
}