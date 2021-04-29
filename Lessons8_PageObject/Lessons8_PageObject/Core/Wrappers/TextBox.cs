using OpenQA.Selenium;

namespace Lessons8_PageObject.Core.Wrappers
{
    public class TextBox 
    {
        private UIElement _uiElement;
        private IJavaScriptExecutor _javaScriptExecutor;

        public TextBox(IWebDriver webDriver, By @by)
        {
            _javaScriptExecutor =(IJavaScriptExecutor) webDriver;
            _uiElement = new UIElement(webDriver, @by);
        }

        public void Click()
        {
            _uiElement.Click();
        }
        public void SendKeys(string text)
        {
            _uiElement.SendKeys(text);
        }

        public void Clear()
        {
            _javaScriptExecutor.ExecuteScript("argument[0].value = '';", _uiElement);//.GetIwebElement наверное для получения элемента с вэйтером
        }

        public string Text => _uiElement.Text;
        public bool Displayed => _uiElement.Displayed;
        
    }
}