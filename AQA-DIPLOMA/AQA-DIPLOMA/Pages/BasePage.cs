using AQA_DIPLOMA.Services;
using OpenQA.Selenium;

namespace AQA_DIPLOMA.Pages;

public abstract class BasePage
{
    protected IWebDriver Driver { get; }
    protected WaitService WaitService { get; }

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
        WaitService = new WaitService(Driver);
    }

    protected abstract By GetPageIdentifier();
    public bool PageOpened => WaitService.WaitElementIsExists(GetPageIdentifier()).Displayed;
}
