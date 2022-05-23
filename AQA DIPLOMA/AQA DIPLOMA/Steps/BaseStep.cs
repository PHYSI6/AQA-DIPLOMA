using AQA_DIPLOMA.Pages;
using OpenQA.Selenium;

namespace AQA_DIPLOMA.Steps;

public class BaseStep
{
    private IWebDriver _driver;
    protected MainPage MainPage;
    protected LoginNavigatorPage LoginNavigatorPage;
    protected LoginPage LoginPage;
    protected ProjectsPage ProjectsPage;

    public BaseStep(IWebDriver driver)
    {
        _driver = driver;
        MainPage = new MainPage(_driver);
        LoginNavigatorPage = new LoginNavigatorPage(_driver);
        LoginPage = new LoginPage(_driver);
        ProjectsPage = new ProjectsPage(_driver);
    }
}
