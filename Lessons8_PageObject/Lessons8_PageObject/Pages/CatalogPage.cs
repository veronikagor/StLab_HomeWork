using System;
using Lessons8_PageObject.BaseEntities;
using OpenQA.Selenium;

namespace Lessons8_PageObject.Pages
{
    public class CatalogPage :BasePage
    {
        
        private static string END_POINT = "inventory.html";

        private static readonly By FooterRobotImage = By.ClassName("footer_robot");

        public static string ItemName;

        private static readonly By AddToCartButton =
            By.XPath(
                $"//*[contains(text(),'{ItemName}')]/ancestor::div[@class='inventory_item_description']//button");
        
        public CatalogPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseUrl + END_POINT);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return _waitService.GetVisibleElement(FooterRobotImage).Displayed; 
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}