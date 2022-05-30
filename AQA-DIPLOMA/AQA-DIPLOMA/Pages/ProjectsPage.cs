using OpenQA.Selenium;

namespace AQA_DIPLOMA.Pages;

public class ProjectsPage : BasePage
{
    private static readonly By NewProjectButtonBy = By.XPath("//a[normalize-space(text()) = 'New project']");
    
    public IWebElement NewProjectButton => WaitService.WaitElementIsExists(NewProjectButtonBy);

    public ProjectsPage(IWebDriver driver) : base(driver)
    {
    }

    protected override By GetPageIdentifier() => NewProjectButtonBy;
}
