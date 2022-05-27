using System;
using AQA_DIPLOMA.Configuration;
using OpenQA.Selenium;

namespace AQA_DIPLOMA.Services.SeleniumServices;

public class BrowserService
{
    private IWebDriver _driver = null!;
    
    public IWebDriver Driver
    {
        get => _driver;
        private set => _driver = value;
    }

    public BrowserService()
    {
        Driver = Configurator.AppSettings.BrowserType?.ToLower() switch
        {
            "chrome" => new DriverFactory().GetChromeDriver(),
            "firefox" => new DriverFactory().GetFirefoxDriver(),
            _ => throw new ArgumentException("Browser type was not found!")
        };
        Driver.Manage().Window.Maximize();
        Driver.Manage().Cookies.DeleteAllCookies();
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
    }
}
