namespace AQA_DIPLOMA.Configuration;

public class AppSettings
{
    public string? BaseUrl { get; init; } = string.Empty;
    public string? BrowserType { get; init; } = string.Empty;
    public string? ApiUrl { get; init; } = string.Empty;
    public int WaitTimeout { get; set; }
}
