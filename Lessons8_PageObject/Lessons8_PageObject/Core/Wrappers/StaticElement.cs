using OpenQA.Selenium;

namespace Lessons8_PageObject.Core.Wrappers
{
    public class StaticElement
    {
        private UIElement _uiElement;

        public StaticElement(IWebDriver webDriver, By @by)
        {
            _uiElement = new UIElement(webDriver, @by);
        }
        
        // public StaticElement(IWebDriver webDriver)
        // {
        //     _uiElement = new UIElement(webDriver);
        // }

        public string GetText()
        {
            return _uiElement.Text;
        }

    }
}