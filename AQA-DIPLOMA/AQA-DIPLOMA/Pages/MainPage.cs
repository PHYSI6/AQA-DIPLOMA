using AQA_DIPLOMA.Configuration;
using OpenQA.Selenium;

namespace AQA_DIPLOMA.Pages;

public class MainPage : BasePage
{
    private const string PathSegment = "/";
    private static readonly By ButtonLoginBy = By.ClassName("login_link");
    
    public IWebElement ButtonLogin => WaitService.WaitElementIsExists(ButtonLoginBy);

    public MainPage(IWebDriver driver) : base(driver)
    {
    }

    protected override By GetPageIdentifier() => ButtonLoginBy;

    public void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.AppSettings.BaseUrl + PathSegment);
    }
}
