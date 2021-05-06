using Lessons8_PageObject.BaseEntities;
using Lessons8_PageObject.Pages;
using Lessons8_PageObject.Steps;
using NUnit.Framework;

namespace Lessons8_PageObject.Tests
{
    [Parallelizable(ParallelScope.All)]
    public class CatalogTests : BaseTest
    {
        [Test]
        public void Test1()
        {
            var loginSteps = new LoginSteps(Driver);
            loginSteps.Login();

            var catalogPage = new CatalogPage(Driver);
            
            var product = catalogPage.GetProduct("Sauce Labs Bike Light");
            var productDescription = product.Description;
            var productPrice = product.Price;

            product.ActionWithProduct.Click();

            Assert.AreEqual(Driver.Title, "Swag Labs");
        }
    }
}