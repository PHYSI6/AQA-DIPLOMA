using FluentAssertions;
using FluentAssertions.Execution;
using OpenQA.Selenium;

namespace AQA_DIPLOMA.Steps;

public class AddProjectSteps: BaseStep
{
    public AddProjectSteps(IWebDriver driver) : base(driver)
    {
    }

    public void ClickButtonNewProjectOnProjectPage()
    {
        ProjectsPage.NewProjectButton.Click();
        NewProjectPage.PageOpened.Should().BeTrue();
    }

    public void InputNewProjectName(string? name)
    {
        NewProjectPage.ProjectName.SendKeys(name);
    }

    public void ClickButtonAddProject()
    {
        NewProjectPage.ButtonAddProject.Click();
    }
    
    public void ProjectAdditionSuccessCheck()
    {
        using (new AssertionScope())
        {
            ProjectOverviewPage.PageOpened.Should().BeTrue();
            ProjectOverviewPage.ProjectCreationStatus.Text.Should().Be("Project was successfully created.");
        }
    }

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
