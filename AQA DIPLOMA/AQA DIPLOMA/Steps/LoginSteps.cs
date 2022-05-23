using FluentAssertions;
using OpenQA.Selenium;

namespace AQA_DIPLOMA.Steps;

public class LoginSteps : BaseStep
{
    public LoginSteps(IWebDriver driver) : base(driver)
    {
    }

    public void OpenMainPage()
    {
        MainPage.OpenPage();
        MainPage.PageOpened.Should().BeTrue();
    }

    public void ClickButtonLoginOnMainPage()
    {
        MainPage.ButtonLogin.Click();
        LoginNavigatorPage.PageOpened.Should().BeTrue();
    }

    public void ClickButtonLoginOnNavigatorPage()
    {
        LoginNavigatorPage.LoginButton.Click();
        LoginPage.PageOpened.Should().BeTrue();
    }

    public void InputUsernameAndPassword(string username, string password)
    {
        LoginPage.UsernameField.SendKeys(username);
        LoginPage.PasswordField.SendKeys(password);
    }

    public void ClickButtonContinue()
    {
        LoginPage.ContinueButton.Click();
    }

    public void AuthorizationSuccessCheck()
    {
        ProjectsPage.PageOpened.Should().BeTrue();
    }

    public void AuthorizationErrorCheck()
    {
        LoginPage.LoginErrorMessage.Displayed.Should().BeTrue();
    }
}
