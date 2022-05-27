using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace AQA_DIPLOMA.Steps;

public class AddProjectSteps : BaseStep
{
    public AddProjectSteps(IWebDriver driver) : base(driver)
    {
    }

    [AllureStep("Click button \"New project\"")]
    public AddProjectSteps ClickButtonNewProjectOnProjectPage()
    {
        ProjectsPage.NewProjectButton.Click();
        NewProjectPage.PageOpened.Should().BeTrue();

        return this;
    }

    [AllureStep("Enter name {0} in \"Name\" field")]
    public AddProjectSteps InputNewProjectName(string? name)
    {
        NewProjectPage.ProjectName.SendKeys(name);
        
        return this;
    }

    [AllureStep("Click button \"Add project\"")]
    public AddProjectSteps ClickButtonAddProject()
    {
        NewProjectPage.ButtonAddProject.Click();
        
        return this;
    }

    [AllureStep("Project addition success check")]
    public AddProjectSteps ProjectAdditionSuccessCheck()
    {
        using (new AssertionScope())
        {
            ProjectOverviewPage.PageOpened.Should().BeTrue();
            ProjectOverviewPage.ProjectCreationStatus.Text.Should().Be("Project was successfully created.");
        }
        
        return this;
    }

    [AllureStep("Project addition error check")]
    public AddProjectSteps ProjectAdditionErrorCheck(string errorMessage)
    {
        using (new AssertionScope())
        {
            NewProjectPage.PageOpened.Should().BeTrue();
            NewProjectPage.ErrorMessage.Displayed.Should().BeTrue();
            NewProjectPage.ErrorMessageText.Text.Should().Be(errorMessage);
        }
        
        return this;
    }
}
