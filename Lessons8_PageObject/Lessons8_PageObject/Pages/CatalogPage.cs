using System;
using Lessons8_PageObject.BaseEntities;
using Lessons8_PageObject.Core.Wrappers;
using OpenQA.Selenium;

namespace Lessons8_PageObject.Pages
{
    public class CatalogPage : BasePage
    {
        private static string END_POINT = "inventory.html";

        private static readonly By FooterRobotImage = By.ClassName("footer_robot");

        private static readonly By ProductSortContainerBy = By.ClassName("product_sort_container");

        public CatalogPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public CatalogPage(IWebDriver driver) : base(driver, false)
        {
        }

        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseUrl + END_POINT);
        }

        public override bool IsPageOpened()
        {
            return _waitService.GetVisibleElement(FooterRobotImage).Displayed;
        }

        public DropDown ProductSortContainer() => new DropDown(Driver, ProductSortContainerBy);

        public ProductOfCatalog GetProduct(string itemName) => new ProductOfCatalog(Driver, itemName);

        public StaticElement ProductDescription(string itemName)
        {
            return new ProductOfCatalog(Driver, itemName).Description;
        }

        public StaticElement ProductPrice(string itemName)
        {
            return new ProductOfCatalog(Driver, itemName).Price;
        }

        public Button ActionWithProduct(string itemName)
        {
            return new ProductOfCatalog(Driver, itemName).ActionWithProduct;
        }
    }
}