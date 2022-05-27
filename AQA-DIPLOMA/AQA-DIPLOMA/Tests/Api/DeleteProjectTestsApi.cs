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
    private Project _project = null!;

    [OneTimeSetUp]
    public void CreateRandomProject()
    {
        _project = new ProjectFaker();
        var actualProject = ProjectService.Create(_project).Result;
        _project = actualProject;
    }

    [Test]
    [Category("Positive")]
    [AllureName("Delete a created project")]
    [AllureStep("Request to delete a created project")]
    [AllureTms("TMS", "expand_section=340958#case_3572024")]
    public void Delete_Existing_Project()
    {
        var deleteStatus = ProjectService.Delete(_project.Id);
        deleteStatus.Should().Be(HttpStatusCode.NoContent);
    }

    [Test]
    [Category("Negative")]
    [AllureName("Delete a non-existing project")]
    [AllureStep("Request to delete a non-existing project")]
    [AllureTms("TMS", "expand_section=340958#case_3572024")]
    public void Delete_Non_Existing_Project()
    {
        var impossibleId = -2;
        
        var deleteStatus = ProjectService.Delete(impossibleId);
        
        deleteStatus.Should().Be(HttpStatusCode.NotFound);
    }
}
