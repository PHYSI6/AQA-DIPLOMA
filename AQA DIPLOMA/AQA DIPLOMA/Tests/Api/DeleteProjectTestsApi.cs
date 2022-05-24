using System.Net;
using AQA_DIPLOMA.Fakers;
using AQA_DIPLOMA.Models;
using FluentAssertions;
using NUnit.Framework;

namespace AQA_DIPLOMA.Tests.Api;

public class DeleteProjectTestsApi : BaseTestApi
{
    private Project? _project;
    
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _project = new ProjectFaker();
        var actualProject = ProjectService?.Create(_project).Result;
        _project = actualProject;
    }
    
    [Test]
    public void Delete_Existing_Project()
    {
        var deleteStatus = ProjectService.Delete(_project.Id);
        deleteStatus.Should().Be(HttpStatusCode.NoContent);
    }

    [Test]
    public void Delete_Non_Existing_Project()
    {
        var nonExisingProjectId = -2;
        var deleteStatus = ProjectService.Delete(nonExisingProjectId);
        deleteStatus.Should().Be(HttpStatusCode.NotFound);
    }
}
