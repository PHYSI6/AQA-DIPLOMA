using AQA_DIPLOMA.Configuration;
using AQA_DIPLOMA.Steps;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace AQA_DIPLOMA.Tests.Ui;

[AllureNUnit]
[AllureParentSuite("UI")]
[AllureSuite("Authorization UI")]
public class AuthorizationTestsUi : BaseTestUi
{
    private LoginSteps _loginSteps = null!;
    [SetUp]
    public void InitSteps()
    {
        _loginSteps = new LoginSteps(_driver);
    }
    
    [Test]
    [Category("Positive")]
    [AllureName("Authorization with correct login and password")]
    public void Authorization_with_correct_data()
    {
        _loginSteps
            .OpenMainPage()
            .ClickButtonLoginOnMainPage()
            .ClickButtonLoginOnNavigatorPage()
            .InputUsernameAndPassword(Configurator.Admin.Email, Configurator.Admin.Password)
            .ClickButtonContinue()
            .AuthorizationSuccessCheck();
    }

    [Test]
    [Category("Negative")]
    [AllureName("Authorization with non-existent login and password")]
    [TestCase("uncorrectmail", "uncorrectpassword")]
    [TestCase("\" = \"", "\" = \"")]
    public void Authorization_with_non_existent_data(string username, string password)
    {
        _loginSteps
            .OpenMainPage()
            .ClickButtonLoginOnMainPage()
            .ClickButtonLoginOnNavigatorPage()
            .InputUsernameAndPassword(username, password)
            .ClickButtonContinue()
            .AuthorizationErrorCheck();
    }

    [Test]
    [AllureName("Authorization with empty login and password")]
    [TestCase(" ", " ")]
    [Category("Negative")]
    public void Authorization_with_empty_data(string username, string password)
    {
        _loginSteps
            .OpenMainPage()
            .ClickButtonLoginOnMainPage()
            .ClickButtonLoginOnNavigatorPage()
            .InputUsernameAndPassword(username, password)
            .ClickButtonContinue()
            .AuthorizationAlertCheck();
    }
}
