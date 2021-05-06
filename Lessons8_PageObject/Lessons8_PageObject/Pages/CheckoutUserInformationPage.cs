using Lessons8_PageObject.BaseEntities;
using Lessons8_PageObject.Core.Wrappers;
using OpenQA.Selenium;

namespace Lessons8_PageObject.Pages
{
    public class CheckoutUserInformationPage : BasePage
    {
        private static string END_POINT = "checkout-step-one.html";

        private static readonly By FirstNameBy = By.Id("first-name");
        
        private static readonly By LastNameBy = By.Id("last-name");
        
        private static readonly By PostalCodeBy = By.Id("postal-code");
        
        private static readonly By ContinueBy = By.Id("continue");
        
        private static readonly By CancelBy = By.Id("cancel");

        public CheckoutUserInformationPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }
        
        public CheckoutUserInformationPage(IWebDriver driver) : base(driver, false)
        {
        }

        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseUrl + END_POINT);
        }

        public override bool IsPageOpened()
        {
            return _waitService.GetVisibleElement(ContinueBy).Displayed;
        }

        public TextBox FirstName() => new TextBox(Driver, FirstNameBy);

        public TextBox LastName() => new TextBox(Driver, LastNameBy);

        public TextBox PostalCode() => new TextBox(Driver, PostalCodeBy);

        public Button Continue() => new Button(Driver, ContinueBy);

        public Button Cancel() => new Button(Driver, CancelBy);
    }
}