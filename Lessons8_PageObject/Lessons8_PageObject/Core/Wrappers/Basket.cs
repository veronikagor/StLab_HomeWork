using System.Collections.Generic;
using OpenQA.Selenium;

namespace Lessons8_PageObject.Core.Wrappers
{
    public class Basket
    {
        private UIElement _uiElement;
        private List<ProductOfBasket> itemList = new List<ProductOfBasket>();
        
        public Basket(IWebDriver webDriver)
        {
            _uiElement = new UIElement(webDriver);

            foreach (var item in _uiElement.FindElements(By.ClassName("cart_item")))
            {
                itemList.Add(new ProductOfBasket(webDriver, item));
            }
        }

        public int ProductCount()
        {
            return itemList.Count;
        }
    }
}