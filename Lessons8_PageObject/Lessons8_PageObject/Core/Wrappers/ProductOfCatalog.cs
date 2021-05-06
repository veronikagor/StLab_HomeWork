using NLog;
using OpenQA.Selenium;

namespace Lessons8_PageObject.Core.Wrappers
{
    public class ProductOfCatalog
    {
        private static Logger _log = LogManager.GetCurrentClassLogger();

        private UIElement _uiElement;
        public Button ActionWithProduct { get; }
        public StaticElement Description { get; }
        public StaticElement Price { get; }


        public ProductOfCatalog(IWebDriver webDriver, string itemName)
        {
            ActionWithProduct = new Button(webDriver, By.XPath(
                $"//*[contains(text(),'{itemName}')]/ancestor::div[@class='inventory_item_description']//button"));

            Description = new StaticElement(webDriver, By.XPath(
                $"//*[contains(text(),'{itemName}')]/ancestor::div[@class='inventory_item_label']//div[@class='inventory_item_desc']"));

            Price = new StaticElement(webDriver, By.XPath(
                $"//*[contains(text(),'{itemName}')]/ancestor::div[@class='inventory_item_description']//div[@class='inventory_item_price']"));
        }

        public ProductOfCatalog(IWebDriver webDriver, IWebElement webElement)
        {
            _uiElement = new UIElement(webDriver, webElement);
        }

        public void AddToCart()
        {
            if (ActionWithProduct.Text.Equals("Add to cart"))
            {
                ActionWithProduct.Click();
            }
            else
            {
                _log.Info("The product was added to the shopping cart.");
            }
        }

        public void RemoveFromCart()
        {
            if (ActionWithProduct.Text.Equals("Remove"))
            {
                ActionWithProduct.Click();
            }
            else
            {
                _log.Info("The product was removed from the shopping cart.");
            }
        }
    }
}