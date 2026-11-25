namespace SelcukSSO.Models.Entities;

public class SSOSession
{
    public Guid SessionId { get; set; } = Guid.NewGuid();

    public string UserId { get; set; } = string.Empty;

    public int ApplicationId { get; set; }

    public string ActiveRoleId { get; set; } = string.Empty;

    public DateTimeOffset CreatedAt { get; set; }
        = DateTimeOffset.UtcNow;

    public DateTimeOffset ExpiresAt { get; set; }

    public DateTimeOffset? RevokedAt { get; set; }

    public int Version { get; set; } = 1;
}