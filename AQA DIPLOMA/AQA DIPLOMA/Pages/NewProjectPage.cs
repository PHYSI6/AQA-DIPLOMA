using OpenQA.Selenium;

namespace AQA_DIPLOMA.Pages;

public class NewProjectPage : BasePage
{
    private static readonly By ProjectNameBy = By.Id("project_name");
    private static readonly By ButtonAddProjectBy = By.XPath("//input[@value='Add project']");
    public IWebElement ProjectName => WaitService.WaitElementIsExists(ProjectNameBy);
    public IWebElement ButtonAddProject => WaitService.WaitElementIsExists(ButtonAddProjectBy);

    public NewProjectPage(IWebDriver driver) : base(driver)
    {
    }

    protected override By GetPageIdentifier()
    {
        return ProjectNameBy;
    }
}
