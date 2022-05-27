using OpenQA.Selenium;

namespace AQA_DIPLOMA.Pages;

public class LoginNavigatorPage : BasePage
{
    private static readonly By LoginButtonBy = By.ClassName("round_green_button");
    
    public IWebElement LoginButton => WaitService.WaitElementIsExists(LoginButtonBy);

    public LoginNavigatorPage(IWebDriver driver) : base(driver)
    {
    }

    protected override By GetPageIdentifier() => LoginButtonBy;
}
