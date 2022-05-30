using System.Text.Json.Serialization;

namespace AQA_DIPLOMA.Models;

public record Projects
{
    [JsonPropertyName("pagination")] public Pagination? Pagination { get; set; }
    
    [JsonPropertyName("projects")] public Project[]? ProjectsList { get; set; }
}
