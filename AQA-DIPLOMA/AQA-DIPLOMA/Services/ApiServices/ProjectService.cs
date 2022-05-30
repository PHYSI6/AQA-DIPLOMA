using System;
using System.Net;
using System.Threading.Tasks;
using AQA_DIPLOMA.Clients;
using AQA_DIPLOMA.Models;
using RestSharp;

namespace AQA_DIPLOMA.Services.ApiServices;

public class ProjectService : IProjectService, IDisposable
{
    private readonly RestClientExtended _client;

    public ProjectService(RestClientExtended client)
    {
        _client = client;
    }

    public Task<Project> Show(int projectId)
    {
        var request = new RestRequest("/projects/{id}.json")
            .AddUrlSegment("id", projectId);
        
        return _client.ExecuteAsync<Project>(request);
    }

    public Task<Projects> List()
    {
        var request = new RestRequest("/projects.json");

        return _client.ExecuteAsync<Projects>(request);
    }

    public Task<Project> Create(Project? project)
    {
        var request = new RestRequest("/projects.json", Method.Post)
            .AddJsonBody(project);
        
        return _client.ExecuteAsync<Project>(request);
    }

    public Task<ErrorResponse> CreateWithInvalidData(Project? project)
    {
        var request = new RestRequest("/projects.json", Method.Post)
            .AddJsonBody(project);
        
        return _client.ExecuteAsync<ErrorResponse>(request);
    }

    public HttpStatusCode Delete(int projectId)
    {
        var request = new RestRequest("/projects/{id}.json", Method.Delete)
            .AddUrlSegment("id", projectId)
            .AddJsonBody("{}");
        
        return _client.ExecuteAsync(request).Result.StatusCode;
    }

    public void Dispose()
    {
        _client.Dispose();
        GC.SuppressFinalize(this);
    }
}
