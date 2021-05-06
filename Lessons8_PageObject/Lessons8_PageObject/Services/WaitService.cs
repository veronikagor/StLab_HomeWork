using System;
using System.Collections.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lessons8_PageObject.Services
{
    public class WaitService
    {
        [ThreadStatic] protected static IWebDriver _driver;
        private WebDriverWait _wait;

        public WaitService(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Configurator.WaitTimeOut));
        }

        public IWebElement GetExistingElement(By by)
        {
            try
            {
                return _wait.Until(ExpectedConditions.ElementExists(by));
            }
            catch (Exception e)
            {
                throw new AssertionException(e.Message);
            }
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

        public ReadOnlyCollection<IWebElement> GetVisibleElements(By by)
        {
            return _wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
        }

        public IWebElement GetClickableElement(IWebElement element)
        {
            try
            {
                return _wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch (Exception e)
            {
                throw new AssertionException(e.Message);
            }
        }

        public IWebElement ExistElement(By by)
        {
            var fluentWait = new DefaultWait<IWebDriver>(_driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(50);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return fluentWait.Until(x => x.FindElement(by));
        }
    }
}