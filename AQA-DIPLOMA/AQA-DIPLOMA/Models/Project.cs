using System.Text.Json.Serialization;

namespace AQA_DIPLOMA.Models;

public record Project
{
    [JsonPropertyName("id")] public int Id { get; set; }
    
    [JsonPropertyName("name")] public string? Name { get; set; }
    
    [JsonPropertyName("description")] public string? Description { get; set; }
    
    [JsonPropertyName("issue_tracker_credential_id")] public int? IssueTrackerCredentialId { get; set; }
    
    [JsonPropertyName("issue_tracker_project_id")] public string? IssueTrackerProjectId { get; set; }
    
    [JsonPropertyName("created_at")] public string? CreatedAt { get; set; }
    
    [JsonPropertyName("updated_at")] public string? UpdatedAt { get; set; }
}
