using System.Net;
using AQA_DIPLOMA.Clients;
using AQA_DIPLOMA.Fakers;
using AQA_DIPLOMA.Models;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace AQA_DIPLOMA.Tests.Api;

public class GetProjectTestApi: BaseTestApi
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
    public void Get_Project()
    {
        var receivedProject = ProjectService?.Show(_project.Id).Result;
        using (new AssertionScope())
        {
            RestClientExtended.LastResponse?.StatusCode.Should().Be(HttpStatusCode.OK);
            receivedProject?.Name.Should().Be(_project?.Name);
            receivedProject?.Description.Should().Be(_project.Description);
        }
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        ProjectService?.Delete(_project.Id);
    }
}
