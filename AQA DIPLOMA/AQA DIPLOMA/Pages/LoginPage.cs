using OpenQA.Selenium;

namespace AQA_DIPLOMA.Pages;

public class LoginPage : BasePage
{
    private static readonly By UsernameFieldBy = By.Id("username");
    private static readonly By PasswordFieldBy = By.Id("password");
    private static readonly By ContinueButtonBy = By.Name("action");
    public IWebElement UsernameField => WaitService.WaitElementIsExists(UsernameFieldBy);
    public IWebElement PasswordField => WaitService.WaitElementIsExists(PasswordFieldBy);
    public IWebElement ContinueButton => WaitService.WaitElementIsExists(ContinueButtonBy);

    public LoginPage(IWebDriver driver) : base(driver)
    {
    }

    protected override By GetPageIdentifier()
    {
        return UsernameFieldBy;
    }
}
