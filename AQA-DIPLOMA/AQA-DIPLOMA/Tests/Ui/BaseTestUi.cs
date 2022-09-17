using System;
using AQA_DIPLOMA.Services.SeleniumServices;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AQA_DIPLOMA.Tests.Ui;

public class BaseTestUi
{
    [ThreadStatic] protected static IWebDriver _driver;

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
