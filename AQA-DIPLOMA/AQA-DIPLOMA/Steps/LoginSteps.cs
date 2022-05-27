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
    public void OpenMainPage()
    {
        MainPage.OpenPage();
        MainPage.PageOpened.Should().BeTrue();
    }
    
    [AllureStep("Click button \"Login\" at the top of the page")]
    public void ClickButtonLoginOnMainPage()
    {
        MainPage.ButtonLogin.Click();
        LoginNavigatorPage.PageOpened.Should().BeTrue();
    }
    
    [AllureStep("On the opened page click button \"Login\"")]
    public void ClickButtonLoginOnNavigatorPage()
    {
        LoginNavigatorPage.LoginButton.Click();
        LoginPage.PageOpened.Should().BeTrue();
    }
    
    [AllureStep("In the authorization form that appears, enter login {0} and password {1}")]
    public void InputUsernameAndPassword(string? username, string? password)
    {
        LoginPage.UsernameField.SendKeys(username);
        LoginPage.PasswordField.SendKeys(password);
    }
    
    [AllureStep("Click button \"Continue\"")]
    public void ClickButtonContinue()
    {
        LoginPage.ContinueButton.Click();
    }
    
    [AllureStep("Authorization success check")]
    public void AuthorizationSuccessCheck()
    {
        ProjectsPage.PageOpened.Should().BeTrue();
    }
    
    [AllureStep("Checking for an authorization error")]
    public void AuthorizationErrorCheck()
    {
        LoginPage.LoginErrorMessage.Displayed.Should().BeTrue();
    }
    
    [AllureStep("Checking for an alert availability")]
    public void AuthorizationAlertCheck()
    {
        IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor) Driver;
        Boolean isValid = (Boolean)javaScriptExecutor.ExecuteScript("return arguments[0].checkValidity();", LoginPage.UsernameField);
        String message = (String)javaScriptExecutor.ExecuteScript("return arguments[0].validationMessage;", LoginPage.UsernameField);
        using (new AssertionScope())
        {
            isValid.Should().BeFalse();
            message.Should().Be("Заполните это поле.");
        }
    }
}
