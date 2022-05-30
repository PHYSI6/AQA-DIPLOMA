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
[AllureSuite("Get a project API")]
public class GetProjectTestApi : BaseTestApi
{
    private Project _project = null!;

    [OneTimeSetUp]
    public void CreateRandomProject()
    {
        _project = new ProjectFaker().Generate();
        var actualProject = ProjectService.Create(_project).Result;
        _project = actualProject;
    }

    [Test]
    [AllureName("Get a existing project")]
    [AllureStep("Request to get a existing project")]
    [AllureTms("TMS", "expand_section=340958#case_3572067")]
    public void Get_Project()
    {
        var receivedProject = ProjectService.Show(_project.Id).Result;
        
        using (new AssertionScope())
        {
            RestClientExtended.LastResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            receivedProject.Name.Should().Be(_project.Name);
            receivedProject.Description.Should().Be(_project.Description);
        }
    }

    [OneTimeTearDown]
    public void DeleteCreatedProject()
    {
        ProjectService.Delete(_project.Id);
    }
}
