using OpenQA.Selenium;

namespace Lessons12_Wrappers.Core.Wrappers
{
    public class CheckBox
    {
        private UIElement _uiElement;

        public CheckBox(IWebDriver webDriver, By @by)
        {
            _uiElement = new UIElement(webDriver, @by);
        }

        public void CheckCheckBox()
        {
            if (!_uiElement.Selected)
            {
                _uiElement.Click();
            }
        }
        
        public void UncheckCheckBox()
        {
            if (_uiElement.Selected)
            {
                _uiElement.Click();
            }
        }
    }
}