using AQA_DIPLOMA.Configuration;
using AQA_DIPLOMA.Fakers;
using AQA_DIPLOMA.Models;
using NUnit.Framework;

namespace AQA_DIPLOMA.Tests.Ui;

public class AddNewProjectTests: BaseTest
{
    private Project? _project;
    [Test]
    [TestCase(1) ,TestCase(149), TestCase(150)]
    public void Add_new_project(int lenghtOfProjectName)
    {
        LoginSteps.OpenMainPage();
        LoginSteps.ClickButtonLoginOnMainPage();
        LoginSteps.ClickButtonLoginOnNavigatorPage();
        LoginSteps.InputUsernameAndPassword(Configurator.Admin.Email, Configurator.Admin.Password);
        LoginSteps.ClickButtonContinue();
        LoginSteps.AuthorizationSuccessCheck();
        AddProjectSteps.ClickButtonNewProjectOnProjectPage();
        _project  = new ProjectFaker(lenghtOfProjectName);
        AddProjectSteps.InputNewProjectName(_project.Name);
        AddProjectSteps.ClickButtonAddProject();
        AddProjectSteps.ProjectAdditionSuccessCheck();
    }
    
    [Test]
    [TestCase(151, "Name is too long (maximum is 150 characters)")]
    [TestCase(0, "Name can't be blank")]
    public void Add_new_proj(int lenghtOfProjectName, string errorText)
    {
        LoginSteps.OpenMainPage();
        LoginSteps.ClickButtonLoginOnMainPage();
        LoginSteps.ClickButtonLoginOnNavigatorPage();
        LoginSteps.InputUsernameAndPassword(Configurator.Admin.Email, Configurator.Admin.Password);
        LoginSteps.ClickButtonContinue();
        LoginSteps.AuthorizationSuccessCheck();
        AddProjectSteps.ClickButtonNewProjectOnProjectPage();
        _project  = new ProjectFaker(lenghtOfProjectName);
        AddProjectSteps.InputNewProjectName(_project.Name);
        AddProjectSteps.ClickButtonAddProject();
        AddProjectSteps.ProjectAdditionErrorCheck(errorText);
    }
}
