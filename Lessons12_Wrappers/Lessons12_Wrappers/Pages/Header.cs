using System;
using Lessons12_Wrappers.Core.Wrappers;
using OpenQA.Selenium;

namespace Lessons12_Wrappers.Pages
{
    public class Header
    {
        [ThreadStatic] protected static IWebDriver Driver;

        private static readonly By HelpAndFeedbackBy = By.Id("navigation-menu");
        private static readonly By UserActionsBy = By.Id("navigation-user");

        public Header(IWebDriver webDriver)
        {
            Driver = webDriver;
        }
        
        public Dropdown UserName() => new Dropdown(Driver, UserActionsBy, "userDropdown");
        public Dropdown HelpAndFeedback() => new Dropdown(Driver, HelpAndFeedbackBy, "helpDropdown");
    }
}