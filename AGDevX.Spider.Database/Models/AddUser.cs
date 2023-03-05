using System;
using System.Collections.Generic;

namespace AGDevX.Spider.Database.Models;

public sealed class AddUser
{
    public Guid CreatedBy { get; set; }
    public bool IsActive { get; set; }
    public required string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public required string LastName { get; set; }
    public string? Suffix { get; set; }
    public required string Email { get; set; }
    public string? ExternalId { get; set; }
    public List<Guid> RoleIds { get; set; } = new List<Guid>();
}