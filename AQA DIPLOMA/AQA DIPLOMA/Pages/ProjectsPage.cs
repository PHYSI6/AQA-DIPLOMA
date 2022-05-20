using OpenQA.Selenium;

namespace AQA_DIPLOMA.Pages;

public class ProjectsPage : BasePage
{
    private static readonly By NewProjectButtonBy = By.XPath("//a[normalize-space(text()) = 'New project']");
    private static readonly By FirstProjectInListBy = By.XPath("(//span[@class='project_title'])[1]");
    private static readonly By LastProjectInListBy = By.XPath("(//span[@class='project_title'])[last()]");
    private static readonly By PageHeadingBy = By.TagName("h1");
    public IWebElement NewProjectButton => WaitService.WaitElementIsExists(NewProjectButtonBy);
    public IWebElement FirstProjectInList => WaitService.WaitElementIsExists(FirstProjectInListBy);
    public IWebElement LastProjectInList => WaitService.WaitElementIsExists(LastProjectInListBy);
    public IWebElement PageHeading => WaitService.WaitElementIsExists(PageHeadingBy);

    public ProjectsPage(IWebDriver driver) : base(driver)
    {
    }

    protected override By GetPageIdentifier()
    {
        return NewProjectButtonBy;
    }
}
