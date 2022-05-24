using System.Text.Json.Serialization;

namespace AQA_DIPLOMA.Models;

public class ErrorResponse
{
    [JsonPropertyName("name")] public string[]? Name { get; set; }
}
