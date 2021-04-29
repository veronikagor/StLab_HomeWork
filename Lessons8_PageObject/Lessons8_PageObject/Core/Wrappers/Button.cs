using OpenQA.Selenium;

namespace Lessons8_PageObject.Core.Wrappers
{
    public class Button
    {
        private UIElement _uiElement;

        public Button(IWebDriver webDriver, By @by)
        {
            _uiElement = new UIElement(webDriver, @by);
        }

        public void Click() => _uiElement.Click();
        
        public string Text => _uiElement.Text;

        public bool Displayed => _uiElement.Displayed;
    }
}