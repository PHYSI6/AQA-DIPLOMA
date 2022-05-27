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
    private Project _project = null!;

    [Test]
    [Category("Positive")]
    [AllureName("Create a new project with an acceptable lenght of name")]
    [AllureStep("Request to create a project with lenght of name {0}")]
    [AllureTms("TMS", "expand_section=340958#case_3572017")]
    [TestCase(1), TestCase(149), TestCase(150)]
    public void Create_New_Project_With_Correct_Data(int lenghtOfProjectName)
    {
        _project = new ProjectFaker(lenghtOfProjectName).Generate();
        var actualProject = ProjectService.Create(_project).Result;
        
        using (new AssertionScope())
        {
            RestClientExtended.LastResponse.StatusCode.Should().Be(HttpStatusCode.Created);
            actualProject.Name.Should().Be(_project.Name);
            actualProject.Description.Should().Be(_project.Description);
        }

        _project = actualProject;
    }

    [Test]
    [Category("Negative")]
    [AllureName("Create a new project with an invalid lenght of name")]
    [AllureStep("Request to create a project with lenght of name {0}")]
    [AllureTms("TMS", "expand_section=340958#case_3572017")]
    [TestCase(0), TestCase(151)]
    public void Create_New_Project_With_Invalid_Data(int lenghtOfProjectName)
    {
        _project = new ProjectFaker(lenghtOfProjectName).Generate();
        ProjectService.CreateWithInvalidData(_project).Wait();
        RestClientExtended.LastResponse.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
    }

    [TearDown]
    public void CleaningUpAddedProjects()
    {
        if ( _project.Id != 0)
        {
            ProjectService.Delete(_project.Id);
        }
    }
}
