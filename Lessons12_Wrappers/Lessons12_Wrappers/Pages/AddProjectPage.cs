using Lessons12_Wrappers.BaseEntities;
using Lessons12_Wrappers.Core.Wrappers;
using OpenQA.Selenium;

namespace Lessons12_Wrappers.Pages
{
    public class AddProjectPage : BasePage
    {
        private static string END_POINT = "index.php?/admin/projects/add/1";
        private readonly By AddProjectBy = By.Id("accept");
        private static readonly By ShowAnnouncementBy = By.Id("show_announcement");
        
        private Header Header { get; }

        public AddProjectPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
            Header = new Header(driver);
        }

        public AddProjectPage(IWebDriver driver) : base(driver, false)
        {
            Header = new Header(driver);
        }

        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseUrl + END_POINT);
        }

        public override bool IsPageOpened()
        {
            return AddProject().Displayed;
        }

        public RadioButton SuiteModel() =>
            new RadioButton(Driver, By.XPath("//*[@class ='radio']//strong/..//input"), "strong");

        public CheckBox ShowAnnouncement() => new CheckBox(Driver, ShowAnnouncementBy);
        public Button AddProject() => new Button(Driver, AddProjectBy);
    }
}