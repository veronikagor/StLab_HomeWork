using System;
using Lessons11_IFrame.Services;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Lessons11_IFrame.BaseEntities
{
    public class BaseTest
    {
        protected WaitService _waitService;
        public static readonly string BaseUrl = Configurator.BaseUrl;

        [ThreadStatic] protected static IWebDriver Driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
        }

        [SetUp]
        public void Setup()
        {
            Driver = new BrowserServices().WebDriver;
            _waitService = new WaitService(Driver); 
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}