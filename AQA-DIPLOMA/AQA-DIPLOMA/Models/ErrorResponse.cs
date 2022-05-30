using System.Text.Json.Serialization;

namespace AQA_DIPLOMA.Models;

public record ErrorResponse
{
    [JsonPropertyName("name")] public string[]? Name { get; set; }
}
