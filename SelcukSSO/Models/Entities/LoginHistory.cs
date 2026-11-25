
namespace SelcukSSO.Models.Entities;

public class LoginHistory
{
    public long Id { get; set; }

    public string? UserId { get; set; }

    public int? ApplicationId { get; set; }

    public DateTimeOffset LoginAt { get; set; }
        = DateTimeOffset.UtcNow;

    public bool IsSuccessful { get; set; }

    public string? IpAddress { get; set; }

    public string? FailureCode { get; set; }
}
