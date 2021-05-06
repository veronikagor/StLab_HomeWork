using Lessons8_PageObject.BaseEntities;
using Lessons8_PageObject.Core.Wrappers;
using OpenQA.Selenium;

namespace Lessons8_PageObject.Pages
{
    public class ShoppingCartPage : BasePage
    {
        private static string END_POINT = "cart.html";

        private static readonly By CheckoutBy = By.Id("checkout");

        private static readonly By ContinueShoppingBy = By.Id("continue-shopping");

        public ShoppingCartPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public ShoppingCartPage(IWebDriver driver) : base(driver, false)
        {
        }

        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseUrl + END_POINT);
        }

        public override bool IsPageOpened()
        {
            return _waitService.GetVisibleElement(CheckoutBy).Displayed;
        }

        public ProductOfBasket Product(string itemName) => new ProductOfBasket(Driver, itemName);

        public StaticElement ProductDescription(string itemName)
        {
            return new ProductOfBasket(Driver, itemName).Description;
        }

        public StaticElement ProductPrice(string itemName)
        {
            return new ProductOfBasket(Driver, itemName).Price;
        }

        public StaticElement Quantity(string itemName)
        {
            return new ProductOfBasket(Driver, itemName).Quantity;
        }

        public Button Remove(string itemName)
        {
            return new ProductOfBasket(Driver, itemName).Remove;
        }

        public Button Checkout() => new Button(Driver, CheckoutBy);
        public Button ContinueShopping() => new Button(Driver, ContinueShoppingBy);
    }
}