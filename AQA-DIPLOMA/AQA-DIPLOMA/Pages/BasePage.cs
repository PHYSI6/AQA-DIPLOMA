using AQA_DIPLOMA.Services;
using AQA_DIPLOMA.Services.SeleniumServices;
using OpenQA.Selenium;

namespace AQA_DIPLOMA.Pages;

public abstract class BasePage
{
    protected IWebDriver Driver { get; }
    
    protected WaitService WaitService { get; }
    
    public bool PageOpened => WaitService.WaitElementIsExists(GetPageIdentifier()).Displayed;

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
        WaitService = new WaitService(Driver);
    }

    protected abstract By GetPageIdentifier();
}
