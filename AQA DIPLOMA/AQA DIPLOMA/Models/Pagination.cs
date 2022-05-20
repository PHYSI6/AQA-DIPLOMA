using System.Text.Json.Serialization;

namespace AQA_DIPLOMA.Models;

public record Pagination
{
    [JsonPropertyName("total_entries")] public int TotalEntries { get; set; }
    [JsonPropertyName("total_pages")] public int TotalPages { get; set; }
    [JsonPropertyName("current_page")] public int CurrentPage { get; set; }
    [JsonPropertyName("next_page")] public string? NextPage { get; set; }
    [JsonPropertyName("previous_page")] public string? PreviousPage { get; set; }
    [JsonPropertyName("per_page")] public int PerPage { get; set; }
}
