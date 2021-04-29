using Lessons12_Wrappers.BaseEntities;
using Lessons12_Wrappers.Core.Wrappers;
using OpenQA.Selenium;

namespace Lessons12_Wrappers.Pages
{
    public class DataManagementPage : BasePage
    {
        private static string END_POINT = "index.php?/admin/subscription";
        private readonly By BodyBy = By.ClassName("tab-body");
        private readonly By ExportsBy = By.Id("navigation-data-management-exports");
        
        private Header Header { get; }
        
        public DataManagementPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
            Header = new Header(driver);
        }

        public DataManagementPage(IWebDriver driver) : base(driver, false)
        {
            Header = new Header(driver);
        }

        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseUrl + END_POINT);
        }

        public override bool IsPageOpened()
        {
            return _waitService.GetVisibleElement(BodyBy).Displayed;
        }

        public Button Exports() => new Button(Driver, ExportsBy);

        public RadioButton SqlVersion() => new RadioButton(Driver, By.XPath("//*[@class ='radio']//p/..//input"), "p");
    }
}