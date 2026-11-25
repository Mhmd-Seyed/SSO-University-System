using Microsoft.AspNetCore.Identity;

namespace SelcukSSO.Models.Identity;

public class ApplicationRole : IdentityRole
{
    public int ApplicationId { get; set; }

    public string Code { get; set; } = string.Empty;

    public string DisplayName { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;
}