using System;
using AQA_DIPLOMA.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AQA_DIPLOMA.Services;

public class WaitService
{
    private IWebDriver _driver;
    private readonly WebDriverWait _explicitWait;
    private readonly DefaultWait<IWebDriver> _fluentWait;

    public WaitService(IWebDriver driver)
    {
        _driver = driver;
            
        _explicitWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Configurator.AppSettings.WaitTimeout));
            
        _fluentWait = new DefaultWait<IWebDriver>(_driver)
        {
            Timeout = TimeSpan.FromSeconds(Configurator.AppSettings.WaitTimeout),
            PollingInterval = TimeSpan.FromMilliseconds(250)
        };
        _fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
    }

    public IWebElement WaitElementIsExists(By locator)
    {
        return _explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
    }
}
