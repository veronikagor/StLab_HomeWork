using Lessons8_PageObject.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lessons8_PageObject.Core.Wrappers
{
    public class DropDown
    {
        private readonly SelectElement _selectElement;
        private readonly By _by;
        public WaitService _waitService;

        public DropDown(IWebDriver webDriver,By @by)
        {
            _waitService = new WaitService(webDriver);
            _by = by;
            _selectElement = new SelectElement(_waitService.GetVisibleElement(by));
        }

        public void SelectByText(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            _selectElement.SelectByText(text);
        }

        public void SelectByValue(string value)
        {
            _selectElement.SelectByText(value);
        }
        
        public void SelectByIndex(string index)
        {
            _selectElement.SelectByText(index);
        }
        
    }
}