using System;
using AQA_DIPLOMA.Services;
using AQA_DIPLOMA.Steps;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AQA_DIPLOMA.Tests.Ui;

public class BaseTest
{
    [ThreadStatic] private static IWebDriver _driver;
    protected LoginSteps LoginSteps;
    protected AddProjectSteps AddProjectSteps;

    [SetUp]
    public void SetUp()
    {
        _driver = new BrowserService().Driver;
        LoginSteps = new LoginSteps(_driver);
        AddProjectSteps = new AddProjectSteps(_driver);
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }

    protected static IWebDriver Driver
    {
        get => _driver;
        set => _driver = value ?? throw new ArgumentNullException(nameof(value));
    }
}
