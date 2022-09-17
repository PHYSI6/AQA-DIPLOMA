using System;
using AQA_DIPLOMA.Services.SeleniumServices;
using AQA_DIPLOMA.Steps;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AQA_DIPLOMA.Tests.Ui;

public class BaseTestUi
{
    [ThreadStatic] protected static IWebDriver _driver;
    protected LoginSteps LoginSteps = null!;
    protected AddProjectSteps AddProjectSteps = null!;
    
    [SetUp]
    public void SetUp()
    {
        _driver = new BrowserService().Driver;
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}
