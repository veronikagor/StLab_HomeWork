using Lessons8_PageObject.BaseEntities;
using Lessons8_PageObject.Core.Wrappers;
using OpenQA.Selenium;

namespace Lessons8_PageObject.Pages
{
    public class CheckoutResultsPage : BasePage
    {
        private static string END_POINT = "checkout-complete.html";
        
        private static readonly By CompleteHeaderBy = By.ClassName("complete-header");
        
        private static readonly By CompleteTextBy = By.ClassName("complete-text");
       
        private static readonly By BackToProductsBy = By.Id("back-to-products");
        
        private static readonly By PonyExpressBy = By.ClassName("pony_express");
        
        public CheckoutResultsPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }
        
        public CheckoutResultsPage(IWebDriver driver) : base(driver, false)
        {
        }

        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseUrl + END_POINT);
        }

        public override bool IsPageOpened()
        {
            return _waitService.GetVisibleElement(PonyExpressBy).Displayed; 
        }
        
        public IWebElement CompleteHeader() => Driver.FindElement(CompleteHeaderBy);
        
        public IWebElement CompleteText() => Driver.FindElement(CompleteTextBy);
        
        public Button BackToProducts() => new Button(Driver, BackToProductsBy);
        
    }
}