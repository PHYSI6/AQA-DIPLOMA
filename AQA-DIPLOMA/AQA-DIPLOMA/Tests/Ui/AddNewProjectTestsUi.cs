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
public class AddNewProjectTestsUi : BaseTestUi
{
    private Project _project = null!;
    private RestClientExtended _client = null!;
    private ProjectService _projectService = null!;

    [OneTimeSetUp]
    public void SetUpClientAndServices()
    {
        _client = new RestClientExtended();
        _projectService = new ProjectService(_client);
    }

    [Test]
    [Category("Positive")]
    [TestCase(1), TestCase(149), TestCase(150)]
    [AllureName("Create a new project with an acceptable lenght of name")]
    [AllureTms("TMS", "expand_section=338413#case_3572037")]
    public void Add_new_project(int lenghtOfProjectName)
    {
        _project = new ProjectFaker(lenghtOfProjectName).Generate();
        
        LoginSteps.OpenMainPage()
            .ClickButtonLoginOnMainPage()
            .ClickButtonLoginOnNavigatorPage()
            .InputUsernameAndPassword(Configurator.Admin.Email, Configurator.Admin.Password)
            .ClickButtonContinue()
            .AuthorizationSuccessCheck();

        AddProjectSteps.ClickButtonNewProjectOnProjectPage()
            .InputNewProjectName(_project.Name)
            .ClickButtonAddProject()
            .ProjectAdditionSuccessCheck();
    }

    [Test]
    [Category("Negative")]
    [AllureName("Create a new project with an invalid lenght of name")]
    [TestCase(151, "Name is too long (maximum is 150 characters)")]
    [TestCase(0, "Name can't be blank")]
    [AllureTms("TMS", "expand_section=338413#case_3572037")]
    public void Add_new_proj(int lenghtOfProjectName, string errorText)
    {
        _project = new ProjectFaker(lenghtOfProjectName).Generate();
        
        LoginSteps.OpenMainPage()
            .ClickButtonLoginOnMainPage()
            .ClickButtonLoginOnNavigatorPage()
            .InputUsernameAndPassword(Configurator.Admin.Email, Configurator.Admin.Password)
            .ClickButtonContinue()
            .AuthorizationSuccessCheck();

        AddProjectSteps.ClickButtonNewProjectOnProjectPage()
            .InputNewProjectName(_project.Name)
            .ClickButtonAddProject()
            .ProjectAdditionErrorCheck(errorText);
    }

    [TearDown]
    public void CleaningUpAddedProjects()
    {
        var listOfProjects = _projectService.List().Result.ProjectsList;
        
        if (listOfProjects == null)
        {
            return;
        }
        
        var addedProject = Array.Find(listOfProjects, project => project.Name == _project.Name);
        
        if (addedProject != null)
        {
            _projectService?.Delete(addedProject.Id);
        }
    }
}
