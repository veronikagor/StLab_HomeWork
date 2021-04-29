using OpenQA.Selenium;

namespace Lessons8_PageObject.Core.Wrappers
{
    public class AddToCartButton : Button
    {
        private static string _itemName;
        
        
        public AddToCartButton(IWebDriver webDriver, By @by, string ItemName) : base(webDriver, @by)
        {
            _itemName = ItemName;
            
            var button = webDriver.FindElements(By.XPath($"//*[contains(text(),'{ItemName}')]/ancestor::div[@class='inventory_item_description']//button"));
        }
    }
}