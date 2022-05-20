using System.Text.Json.Serialization;

namespace AQA_DIPLOMA.Models;

public record Projects
{
    [JsonPropertyName("projects")] public Project[]? ProjectsList { get; set; }
}
