
namespace SelcukSSO.Models.Entities;

public class AuditLog
{
    public long Id { get; set; }

    public string? ActorUserId { get; set; }

    public string? TargetUserId { get; set; }

    public int? ApplicationId { get; set; }

    public string Action { get; set; } = string.Empty;

    public string EntityName { get; set; } = string.Empty;

    public string EntityId { get; set; } = string.Empty;

    public DateTimeOffset CreatedAt { get; set; }
        = DateTimeOffset.UtcNow;

    public string? Details { get; set; }
}