using System.Net;
using AQA_DIPLOMA.Fakers;
using AQA_DIPLOMA.Models;
using FluentAssertions;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace AQA_DIPLOMA.Tests.Api;

[AllureNUnit]
[AllureParentSuite("API")]
[AllureSuite("Delete a project API")]
public class DeleteProjectTestsApi : BaseTestApi
{
    private Project? _project;

    [OneTimeSetUp]
    public void CreateRandomProject()
    {
        _project = new ProjectFaker();
        var actualProject = ProjectService?.Create(_project).Result;
        _project = actualProject;
    }

    [Test]
    [AllureStep("Request to delete a created project")]
    public void Delete_Existing_Project()
    {
        var deleteStatus = ProjectService.Delete(_project.Id);
        deleteStatus.Should().Be(HttpStatusCode.NoContent);
    }

    [Test]
    [AllureStep("Request to delete a non-existing project")]
    public void Delete_Non_Existing_Project()
    {
        var nonExisingProjectId = -2;
        var deleteStatus = ProjectService!.Delete(nonExisingProjectId);
        deleteStatus.Should().Be(HttpStatusCode.NotFound);
    }
}
