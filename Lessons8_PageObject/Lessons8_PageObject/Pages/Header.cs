using System;
using OpenQA.Selenium;

namespace Lessons8_PageObject.Pages
{
    public class Header
    {
        [ThreadStatic] protected static IWebDriver Driver;

        private static readonly By OpenMenuBy = By.XPath("//*[@class='bm-menu-wrap']");

        private static readonly By ShoppingCartLinkBy = By.ClassName("shopping_cart_link");

        public Header(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        public void SelectAllItems()
        {
            if (OpenMenu().GetAttribute("aria-hidden").Equals("true"))
            {
                OpenMenu().Click();
            }

            OpenMenu().FindElement(By.XPath(".//*[@id='inventory_sidebar_link']")).Click();
        }

        public void SelectAbout()
        {
            if (OpenMenu().GetAttribute("aria-hidden").Equals("true"))
            {
                OpenMenu().Click();
            }

            OpenMenu().FindElement(By.XPath(".//*[@id='about_sidebar_link']")).Click();
        }

        public void SelectLogOut()
        {
            if (OpenMenu().GetAttribute("aria-hidden").Equals("true"))
            {
                OpenMenu().Click();
            }

            OpenMenu().FindElement(By.XPath(".//*[@id='logout_sidebar_link']")).Click();
        }

        public void SelectResetAppState()
        {
            if (OpenMenu().GetAttribute("aria-hidden").Equals("true"))
            {
                OpenMenu().Click();
            }

            OpenMenu().FindElement(By.XPath(".//*[@id='reset_sidebar_link']")).Click();
        }

        public IWebElement OpenMenu() => Driver.FindElement(OpenMenuBy);

        public IWebElement ShoppingCartLink() => Driver.FindElement(ShoppingCartLinkBy);
    }
}