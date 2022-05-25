using AQA_DIPLOMA.Configuration;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace AQA_DIPLOMA.Tests.Ui;

[AllureNUnit]
[AllureParentSuite("UI")]
[AllureSuite("Authorization UI")]
public class AuthorizationTests : BaseTest
{
    [Test]
    public void Authorization_with_correct_data()
    {
        LoginSteps.OpenMainPage();
        LoginSteps.ClickButtonLoginOnMainPage();
        LoginSteps.ClickButtonLoginOnNavigatorPage();
        LoginSteps.InputUsernameAndPassword(Configurator.Admin.Email, Configurator.Admin.Password);
        LoginSteps.ClickButtonContinue();
        LoginSteps.AuthorizationSuccessCheck();
    }

    [Test]
    [TestCase("non-existentmail@aqa.by", "ilikeaqa")]
    [TestCase("\"=\"", "\"=\"")]
    public void Authorization_with_non_existent_data(string username, string password)
    {
        LoginSteps.OpenMainPage();
        LoginSteps.ClickButtonLoginOnMainPage();
        LoginSteps.ClickButtonLoginOnNavigatorPage();
        LoginSteps.InputUsernameAndPassword(username, password);
        LoginSteps.ClickButtonContinue();
        LoginSteps.AuthorizationErrorCheck();
    }

    [Test]
    public void Authorization_with_empty_data()
    {
        LoginSteps.OpenMainPage();
        LoginSteps.ClickButtonLoginOnMainPage();
        LoginSteps.ClickButtonLoginOnNavigatorPage();
        LoginSteps.InputUsernameAndPassword("", "");
        LoginSteps.ClickButtonContinue();
        LoginSteps.AuthorizationAlertCheck();
    }
}
