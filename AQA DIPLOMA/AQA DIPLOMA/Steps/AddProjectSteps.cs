using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace AQA_DIPLOMA.Steps;

public class AddProjectSteps: BaseStep
{
    public AddProjectSteps(IWebDriver driver) : base(driver)
    {
    }
    
    [AllureStep("Click button \"New project\"")]
    public void ClickButtonNewProjectOnProjectPage()
    {
        ProjectsPage.NewProjectButton.Click();
        NewProjectPage.PageOpened.Should().BeTrue();
    }
    
    [AllureStep("Enter in \"Name\" field")]
    public void InputNewProjectName(string? name)
    {
        NewProjectPage.ProjectName.SendKeys(name);
    }
    
    [AllureStep("Click button \"Add project\"")]
    public void ClickButtonAddProject()
    {
        NewProjectPage.ButtonAddProject.Click();
    }
    
    [AllureStep("Project addition success check")]
    public void ProjectAdditionSuccessCheck()
    {
        using (new AssertionScope())
        {
            ProjectOverviewPage.PageOpened.Should().BeTrue();
            ProjectOverviewPage.ProjectCreationStatus.Text.Should().Be("Project was successfully created.");
        }
    }
    
    [AllureStep("Project addition error check")]
    public void ProjectAdditionErrorCheck(string errorMessage)
    {
        using (new AssertionScope())
        {
            NewProjectPage.PageOpened.Should().BeTrue();
            NewProjectPage.ErrorMessage.Displayed.Should().BeTrue();
            NewProjectPage.ErrorMessageText.Text.Should().Be(errorMessage);
        }
    }
}
