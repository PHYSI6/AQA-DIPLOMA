using System;
using AQA_DIPLOMA.Clients;
using AQA_DIPLOMA.Configuration;
using AQA_DIPLOMA.Fakers;
using AQA_DIPLOMA.Models;
using AQA_DIPLOMA.Services.ApiServices;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace AQA_DIPLOMA.Tests.Ui;

[AllureNUnit]
[AllureParentSuite("UI")]
[AllureSuite("Add a project UI")]
public class AddNewProjectTests : BaseTest
{
    private Project? _project;
    private RestClientExtended _client;
    private ProjectService? _projectService;

    [OneTimeSetUp]
    public void SetUpClientAndServices()
    {
        _client = new RestClientExtended();
        _projectService = new ProjectService(_client);
    }

    [Test]
    [TestCase(1), TestCase(149), TestCase(150)]
    [AllureTms("TMS", "/a/32159/projects/48292/suites/205720")]
    public void Add_new_project(int lenghtOfProjectName)
    {
        LoginSteps.OpenMainPage();
        LoginSteps.ClickButtonLoginOnMainPage();
        LoginSteps.ClickButtonLoginOnNavigatorPage();
        LoginSteps.InputUsernameAndPassword(Configurator.Admin.Email, Configurator.Admin.Password);
        LoginSteps.ClickButtonContinue();
        LoginSteps.AuthorizationSuccessCheck();
        AddProjectSteps.ClickButtonNewProjectOnProjectPage();
        _project = new ProjectFaker(lenghtOfProjectName);
        AddProjectSteps.InputNewProjectName(_project.Name);
        AddProjectSteps.ClickButtonAddProject();
        AddProjectSteps.ProjectAdditionSuccessCheck();
    }

    [Test]
    [TestCase(151, "Name is too long (maximum is 150 characters)")]
    [TestCase(0, "Name can't be blank")]
    [AllureTms("TMS", "/a/32159/projects/48292/suites/205720")]
    public void Add_new_proj(int lenghtOfProjectName, string errorText)
    {
        LoginSteps.OpenMainPage();
        LoginSteps.ClickButtonLoginOnMainPage();
        LoginSteps.ClickButtonLoginOnNavigatorPage();
        LoginSteps.InputUsernameAndPassword(Configurator.Admin.Email, Configurator.Admin.Password);
        LoginSteps.ClickButtonContinue();
        LoginSteps.AuthorizationSuccessCheck();
        AddProjectSteps.ClickButtonNewProjectOnProjectPage();
        _project = new ProjectFaker(lenghtOfProjectName);
        AddProjectSteps.InputNewProjectName(_project.Name);
        AddProjectSteps.ClickButtonAddProject();
        AddProjectSteps.ProjectAdditionErrorCheck(errorText);
    }

    [TearDown]
    public void CleaningUpAddedProjects()
    {
        var listOfProjects = _projectService?.List().Result.ProjectsList;
        if (listOfProjects == null) return;
        var addedProject = Array.Find(listOfProjects, p => p.Name == _project?.Name);
        if (addedProject != null) _projectService?.Delete(addedProject.Id);
    }
}
