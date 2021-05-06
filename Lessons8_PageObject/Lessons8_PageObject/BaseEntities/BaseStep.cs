﻿using System;
using OpenQA.Selenium;

namespace Lessons8_PageObject.BaseEntities
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