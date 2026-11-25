namespace SelcukSSO.Models.Entities;

public class Application
{
    public int Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string BaseUrl { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;
}