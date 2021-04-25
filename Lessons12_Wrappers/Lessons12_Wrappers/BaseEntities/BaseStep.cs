using System;
using OpenQA.Selenium;

namespace Lessons12_Wrappers.BaseEntities
{
    public class BaseStep
    {
        [ThreadStatic] protected static IWebDriver Driver;

        public BaseStep(IWebDriver driver)
        {
            Driver = driver;
        }
        
    }
}