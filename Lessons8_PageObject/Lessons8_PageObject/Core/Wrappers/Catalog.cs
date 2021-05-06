using System.Collections.Generic;
using OpenQA.Selenium;

namespace Lessons8_PageObject.Core.Wrappers
{
    public class Catalog
    {
        private UIElement _uiElement;
        private List<ProductOfCatalog> itemList = new List<ProductOfCatalog>();

        public Catalog(IWebDriver webDriver)
        {
            _uiElement = new UIElement(webDriver);

            foreach (var item in _uiElement.FindElements(By.ClassName("inventory_item")))
            {
                itemList.Add(new ProductOfCatalog(webDriver, item));
            }
        }

        public int ProductCount()
        {
            return itemList.Count;
        }
    }
}