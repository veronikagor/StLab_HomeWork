using System;
using Lessons12_Wrappers.Services;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Lessons12_Wrappers.BaseEntities
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