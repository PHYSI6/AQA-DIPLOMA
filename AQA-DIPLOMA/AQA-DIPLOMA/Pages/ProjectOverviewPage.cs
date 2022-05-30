using OpenQA.Selenium;

namespace AQA_DIPLOMA.Pages;

public class ProjectOverviewPage : BasePage
{
    private static readonly By PageHeadingBy = By.TagName("h1");
    private static readonly By ProjectCreationStatusBy = By.XPath("//div[@class='flash_notification']//p");
    
    public IWebElement ProjectCreationStatus => WaitService.WaitElementIsExists(ProjectCreationStatusBy);

    public ProjectOverviewPage(IWebDriver driver) : base(driver)
    {
    }

    protected override By GetPageIdentifier() => PageHeadingBy;
}
