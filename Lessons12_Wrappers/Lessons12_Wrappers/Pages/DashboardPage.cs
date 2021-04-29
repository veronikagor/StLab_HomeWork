using Lessons12_Wrappers.BaseEntities;
using Lessons12_Wrappers.Core.Wrappers;
using OpenQA.Selenium;

namespace Lessons12_Wrappers.Pages
{
    public class DashboardPage : BasePage
    {
        private static string END_POINT = "index.php?/dashboard";
        private static readonly By SidebarProjectsAddButtonBy = By.Id("sidebar-projects-add");
        
        public Header Header { get; }
        
        public DashboardPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
            Header = new Header(driver);
        }

        public DashboardPage(IWebDriver driver) : base(driver, false)
        {
            Header = new Header(driver);
        }

        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseUrl + END_POINT);
        }

        public override bool IsPageOpened()
        {
            return SidebarProjectsAdd().Displayed;
        }

        public Button SidebarProjectsAdd() => new Button(Driver, SidebarProjectsAddButtonBy);
       
    }
}