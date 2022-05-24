using System.Net;
using AQA_DIPLOMA.Clients;
using AQA_DIPLOMA.Fakers;
using AQA_DIPLOMA.Models;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace AQA_DIPLOMA.Tests.Api;

public class CreateNewProjectTests : BaseTestApi
{
    private Project? _project;
    [Test]
    [TestCase(1),TestCase(149), TestCase(150)]
    public void Create_New_Project_With_Correct_Data(int lenghtOfProjectName)
    {
        _project = new ProjectFaker(lenghtOfProjectName);
        var actualProject = ProjectService?.Create(_project).Result;
        using (new AssertionScope())
        {
            RestClientExtended.LastResponse?.StatusCode.Should().Be(HttpStatusCode.Created);
            actualProject?.Name.Should().Be(_project.Name);
            actualProject?.Description.Should().Be(_project.Description);
        }
        if (actualProject != null) ProjectService?.Delete(actualProject.Id);
    }
    
    [Test]
    [TestCase(0), TestCase(151)]
    public void Create_New_Project_With_Invalid_Data(int lenghtOfProjectName)
    {
        _project = new ProjectFaker(lenghtOfProjectName);
        var actualProject = ProjectService?.CreateWithInvalidData(_project).Result;
        RestClientExtended.LastResponse?.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
    }
}
