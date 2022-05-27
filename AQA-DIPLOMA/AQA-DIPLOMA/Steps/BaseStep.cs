using System;
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
    protected NewProjectPage NewProjectPage;
    protected ProjectOverviewPage ProjectOverviewPage;

    public BaseStep(IWebDriver driver)
    {
        _driver = driver;
        MainPage = new MainPage(_driver);
        LoginNavigatorPage = new LoginNavigatorPage(_driver);
        LoginPage = new LoginPage(_driver);
        ProjectsPage = new ProjectsPage(_driver);
        NewProjectPage = new NewProjectPage(_driver);
        ProjectOverviewPage = new ProjectOverviewPage(_driver);
    }

    protected IWebDriver Driver
    {
        get => _driver;
        set => _driver = value ?? throw new ArgumentNullException(nameof(value));
    }
}
