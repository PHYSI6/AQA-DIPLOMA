using System.Net;
using System.Threading.Tasks;
using AQA_DIPLOMA.Models;

namespace AQA_DIPLOMA.Services;

public interface IProjectService
{
    Task<Project> Show(int projectId);
    Task<Projects> List();
    Task<Project> Create(Project? project);
    HttpStatusCode Delete(int projectId);
}
