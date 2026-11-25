using Microsoft.AspNetCore.Identity;

namespace SelcukSSO.Models.Identity;

public class ApplicationUserRole : IdentityUserRole<string>
{
    public DateTimeOffset AssignedAt { get; set; }
        = DateTimeOffset.UtcNow;

    public DateTimeOffset? ExpiresAt { get; set; }

    public bool IsActive { get; set; } = true;
}