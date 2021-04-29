using System;
using System.Collections.ObjectModel;
using System.Drawing;
using Lessons8_PageObject.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Lessons8_PageObject.Core.Wrappers
{
    public class UIElement : IWebElement
    {
        protected static IWebDriver _webDriver;
        protected By _by;
        private IWebElement _webElementImplementation;
        private Actions _actions;
        private IJavaScriptExecutor _javaScriptExecutor;
        protected WaitService _waitService; 

        public UIElement(IWebDriver webDriver, By @by)
        {
            _webDriver = webDriver;
            _by = @by;
            _webElementImplementation = webDriver.FindElement(@by);
            _actions = new Actions(webDriver);
            _javaScriptExecutor = (IJavaScriptExecutor) webDriver;
            _waitService = new WaitService(webDriver);
        }

        public UIElement(IWebDriver webDriver, IWebElement webElement)
        {
            _webDriver = webDriver;
            _webElementImplementation = webElement;
            _waitService = new WaitService(webDriver);
            _actions = new Actions(webDriver);
        }    
        
        public UIElement(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _waitService = new WaitService(webDriver);
            _actions = new Actions(webDriver);
        }

        public void Hover()
        {
            _actions.MoveToElement(_webElementImplementation).Build().Perform();
        }

        public void Clear()
        {
            _webElementImplementation.Clear();
        }

        public void SendKeys(string text)
        {
            _webElementImplementation.SendKeys(text);
        }

        public void Submit()
        {
            _webElementImplementation.Submit();
        }

        public void Click()
        {
            try
            {
                _webElementImplementation.Click();
            }
            catch (Exception e)
            {
                try
                {
                    _actions
                        .MoveToElement(_webElementImplementation)
                        .Click()
                        .Build()
                        .Perform();
                }
                catch (Exception exception)
                {
                    _javaScriptExecutor.ExecuteScript("argument[0].click();",_webElementImplementation);
                }
            }
        }

        public string GetAttribute(string attributeName)
        {
            return _webElementImplementation.GetAttribute(attributeName);
        }

        public string GetProperty(string propertyName)
        {
            return _webElementImplementation.GetProperty(propertyName);
        }

        public string GetCssValue(string propertyName)
        {
            return _webElementImplementation.GetCssValue(propertyName);
        }

        public string TagName => _webElementImplementation.TagName;
        
        public string Text => _webElementImplementation.Text;
        
        public bool Enabled => _webElementImplementation.Enabled;
        
        public bool Selected => _webElementImplementation.Selected;
        
        public Point Location => _webElementImplementation.Location;
        
        public Size Size => _webElementImplementation.Size;
        
        public bool Displayed => _webElementImplementation.Displayed;
        
        public IWebElement FindElement(By @by)
        {
            return _webElementImplementation.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By @by)
        {
            return _webElementImplementation.FindElements(by);        }
    }
}