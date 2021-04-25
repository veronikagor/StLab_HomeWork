using System;
using System.Threading;
using Lessons12_Wrappers.Services;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Lessons12_Wrappers.BaseEntities
{
    public abstract class BasePage
    {
        protected static int WAIT_FOR_PAGE_LOADING_TIME = 60;

        [ThreadStatic] protected static IWebDriver Driver;
        protected WaitService _waitService;
        public static string BaseUrl;

        protected abstract void OpenPage();

        public abstract bool IsPageOpened();

        public BasePage(IWebDriver driver, bool openPageByUrl)
        {
            Driver = driver;
            _waitService = new WaitService(Driver);
            BaseUrl = Configurator.BaseUrl;

            if (!openPageByUrl)
            {
                OpenPage();
            }

            WaitForOpen();
        }

        protected void WaitForOpen()
        {
            var secondsCount = 0;
            var isPageOpenedIndicator = IsPageOpened();

            while (!isPageOpenedIndicator && secondsCount < WAIT_FOR_PAGE_LOADING_TIME)
            {
                Thread.Sleep(1000);
                secondsCount++;
                isPageOpenedIndicator = IsPageOpened();
            }

            if (!isPageOpenedIndicator)
            {
                throw new AssertionException("Page was not opened.");
            }
        }
    }
}