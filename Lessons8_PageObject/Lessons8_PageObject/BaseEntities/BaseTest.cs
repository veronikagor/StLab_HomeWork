using System;
using Lessons8_PageObject.Services;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Lessons8_PageObject.BaseEntities
{
    public class BaseTest
    {
        [ThreadStatic] protected static IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            Driver = new BrowserServices().WebDriver;
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}