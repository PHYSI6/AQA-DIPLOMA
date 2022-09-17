using System;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace AQA_DIPLOMA.Steps;

public class LoginSteps : BaseStep
{
    public LoginSteps(IWebDriver driver) : base(driver)
    {
    }
    
    [AllureStep("Open main TestLodge page")]
    public LoginSteps OpenMainPage()
    {
        MainPage.OpenPage();
        MainPage.PageOpened.Should().BeTrue();

        return this;
    }
    
    [AllureStep("Click button \"Login\" at the top of the page")]
    public LoginSteps ClickButtonLoginOnMainPage()
    {
        MainPage.ButtonLogin.Click();
        LoginNavigatorPage.PageOpened.Should().BeTrue();

        return this;
    }
    
    [AllureStep("On the opened page click button \"Login\"")]
    public LoginSteps ClickButtonLoginOnNavigatorPage()
    {
        LoginNavigatorPage.LoginButton.Click();
        LoginPage.PageOpened.Should().BeTrue();

        return this;
    }
    
    [AllureStep("In the authorization form that appears, enter login {0} and password {1}")]
    public LoginSteps InputUsernameAndPassword(string? username, string? password)
    {
        LoginPage.UsernameField.SendKeys(username);
        LoginPage.PasswordField.SendKeys(password);

        return this;
    }
    
    [AllureStep("Click button \"Continue\"")]
    public LoginSteps ClickButtonContinue()
    {
        LoginPage.ContinueButton.Click();

        return this;
    }
    
    [AllureStep("Authorization success check")]
    public AddProjectSteps AuthorizationSuccessCheck()
    {
        ProjectsPage.PageOpened.Should().BeTrue();

        return new AddProjectSteps(Driver);
    }
    
    [AllureStep("Checking for an authorization error")]
    public LoginSteps AuthorizationErrorCheck()
    {
        LoginPage.LoginErrorMessage.Displayed.Should().BeTrue();

        return this;
    }
    
    [AllureStep("Checking for an alert availability")]
    public LoginSteps AuthorizationAlertCheck()
    {
        IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor) Driver;
        
        bool isValid = (Boolean)javaScriptExecutor.ExecuteScript
            ("return arguments[0].checkValidity();", LoginPage.UsernameField);
        
        string message = (String)javaScriptExecutor.ExecuteScript
            ("return arguments[0].validationMessage;", LoginPage.UsernameField);
        
        using (new AssertionScope())
        {
            isValid.Should().BeFalse();
            message.Should().Be("Заполните это поле.");
        }

        return this;
    }
}
