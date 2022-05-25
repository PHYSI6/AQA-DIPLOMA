using System.Net;
using AQA_DIPLOMA.Clients;
using AQA_DIPLOMA.Fakers;
using AQA_DIPLOMA.Models;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace AQA_DIPLOMA.Tests.Api;

[AllureNUnit]
[AllureParentSuite("API")]
[AllureSuite("Create a new project API")]
public class CreateNewProjectTests : BaseTestApi
{
    private Project? _project;

    [Test]
    [AllureStep("Request to create a project with correct data")]
    [TestCase(1), TestCase(149), TestCase(150)]
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

        _project = actualProject;
    }

    [Test]
    [AllureStep("Request to create a project with invalid data")]
    [TestCase(0), TestCase(151)]
    public void Create_New_Project_With_Invalid_Data(int lenghtOfProjectName)
    {
        _project = new ProjectFaker(lenghtOfProjectName);
        var actualProject = ProjectService?.CreateWithInvalidData(_project).Result;
        RestClientExtended.LastResponse?.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
    }

    [TearDown]
    public void CleaningUpAddedProjects()
    {
        if (_project != null && _project.Id != 0)
        {
            ProjectService?.Delete(_project!.Id);
        }
    }
}
