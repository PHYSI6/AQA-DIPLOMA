using AQA_DIPLOMA.Configuration.Enums;

namespace AQA_DIPLOMA.Configuration;

public class User
{
    public UserType UserType { get; set; }
    public string? Email { get; init; } = string.Empty;
    public string? Password { get; init; } = string.Empty;
    public string? Token { get; init; } = string.Empty;
}
