using AQA_DIPLOMA.Configuration;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace AQA_DIPLOMA.Tests.Ui;

[AllureNUnit]
[AllureParentSuite("UI")]
[AllureSuite("Authorization UI")]
public class AuthorizationTestsUi : BaseTestUi
{
    [Test]
    [Category("Positive")]
    [AllureName("Authorization with correct login and password")]
    [AllureTms("TMS", "expand_section=338413#case_3571834")]
    public void Authorization_with_correct_data()
    {
        LoginSteps.OpenMainPage()
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
    [AllureTms("TMS", "expand_section=338413#case_3571834")]
    public void Authorization_with_non_existent_data(string username, string password)
    {
        LoginSteps.OpenMainPage()
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
    [AllureTms("TMS", "expand_section=338413#case_3571834")]
    public void Authorization_with_empty_data(string username, string password)
    {
        LoginSteps.OpenMainPage()
            .ClickButtonLoginOnMainPage()
            .ClickButtonLoginOnNavigatorPage()
            .InputUsernameAndPassword(username, password)
            .ClickButtonContinue()
            .AuthorizationAlertCheck();
    }
}
