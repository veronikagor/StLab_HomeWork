using Lessons8_PageObject.BaseEntities;
using OpenQA.Selenium;

namespace Lessons8_PageObject.Pages
{
    public class CheckoutUserInformation:BasePage
    {
        public CheckoutUserInformation(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        protected override void OpenPage()
        {
            
        }

        public override bool IsPageOpened()
        {
            throw new System.NotImplementedException();
        }
    }
}