using System;
using Lessons8_PageObject.BaseEntities;
using Lessons8_PageObject.Core.Wrappers;
using OpenQA.Selenium;

namespace Lessons8_PageObject.Pages
{
    public class CheckoutOverviewPage : BasePage
    {
        private static string END_POINT = "checkout-step-two.html";

        private static readonly By PaymentInformationBy =
            By.XPath(
                "(//*[contains(text(),'Payment Information:')]/following-sibling::div[@class='summary_value_label'])[1]");

        private static readonly By ShippingInformationBy =
            By.XPath(
                "(//*[contains(text(),'Payment Information:')]/following-sibling::div[@class='summary_value_label'])[2]");

        private static readonly By SummarySubtotalBy = By.ClassName("summary_subtotal_label");

        private static readonly By SummaryTaxBy = By.ClassName("summary_tax_label");

        private static readonly By SummaryTotalBy = By.ClassName("summary_total_label");

        private static readonly By FinishBy = By.Id("finish");

        private static readonly By CancelBy = By.Id("cancel");

        public CheckoutOverviewPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public CheckoutOverviewPage(IWebDriver driver) : base(driver, false)
        {
        }

        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseUrl + END_POINT);
        }

        public override bool IsPageOpened()
        {
            return _waitService.GetVisibleElement(FinishBy).Displayed;
        }

        public ProductOfBasket Product(string itemName) => new ProductOfBasket(Driver, itemName);


        public StaticElement ProductDescription(string itemName)
        {
            return new ProductOfBasket(Driver, itemName).Description;
        }

        public StaticElement ProductPrice(string itemName)
        {
            return new ProductOfBasket(Driver, itemName).Price;
        }

        public StaticElement Quantity(string itemName)
        {
            return new ProductOfBasket(Driver, itemName).Quantity;
        }

        public StaticElement PaymentInformation(string itemName) => new StaticElement(Driver, PaymentInformationBy);
        public StaticElement ShippingInformation(string itemName) => new StaticElement(Driver, ShippingInformationBy);
        public StaticElement SummarySubtotal(string itemName) => new StaticElement(Driver, SummarySubtotalBy);
        public StaticElement SummaryTax(string itemName) => new StaticElement(Driver, SummaryTaxBy);
        public StaticElement SummaryTotal(string itemName) => new StaticElement(Driver, SummaryTotalBy);
    }
}