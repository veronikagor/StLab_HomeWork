using OpenQA.Selenium;

namespace Lessons8_PageObject.Core.Wrappers
{
    public class ProductOfBasket
    {
        private UIElement _uiElement;

        public Button Remove { get; }

        public StaticElement Description { get; }

        public StaticElement Price { get; }

        public StaticElement Quantity { get; }

        public ProductOfBasket(IWebDriver webDriver, string itemName)
        {
            Remove = new Button(webDriver, By.XPath(
                $"//*[contains(text(),'{itemName}')]/ancestor::div[@class='cart_item']//button"));

            Description = new StaticElement(webDriver, By.XPath(
                $"//*[contains(text(),'{itemName}')]/ancestor::div[@class='cart_item_label']//div[@class='inventory_item_desc']"));

            Price = new StaticElement(webDriver, By.XPath(
                $"//*[contains(text(),'{itemName}')]/ancestor::div[@class='cart_item_label']//div[@class='inventory_item_price']"));

            Quantity = new StaticElement(webDriver, By.XPath(
                $"//*[contains(text(),'{itemName}')]/ancestor::div[@class='cart_item']//div[@class='cart_quantity']"));
        }

        public ProductOfBasket(IWebDriver webDriver, IWebElement webElement)
        {
            _uiElement = new UIElement(webDriver, webElement);
        }
    }
}