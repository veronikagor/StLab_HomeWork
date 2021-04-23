using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lessons11_IFrame.Services
{
    public class WaitService
    {
        [ThreadStatic] protected IWebDriver _driver;
        private WebDriverWait _wait;

        public WaitService(IWebDriver driver) 
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Configurator.WaitTimeOut));
        }

        public IWebElement GetVisibleElement(By by) 
        {
            try
            {
                return _wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception e)
            {
                throw new AssertionException(e.Message);
            }
        }
    }
}