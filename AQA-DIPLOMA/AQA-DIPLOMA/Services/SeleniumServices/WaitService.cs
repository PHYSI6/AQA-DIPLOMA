using System;
using AQA_DIPLOMA.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AQA_DIPLOMA.Services.SeleniumServices;

public class WaitService
{
    private readonly WebDriverWait _explicitWait;

    public WaitService(IWebDriver driver)
    {
        _explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(Configurator.AppSettings.WaitTimeout));
    }

    public IWebElement WaitElementIsExists(By locator)
    {
        return _explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
    }
}
