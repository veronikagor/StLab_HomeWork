using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Lessons6_Selenium
{
    public class CalculationTests
    {
        private static IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            _driver.Navigate().GoToUrl(@"https://www.calc.ru/kalkulyator-kalorii.html");

            var activity = new SelectElement(_driver.FindElement(By.Id("activity")));
            activity.SelectByText("5 раз в неделю");

            var age = _driver.FindElement(By.Id("age"));
            var weight = _driver.FindElement(By.Id("weight"));
            var height = _driver.FindElement(By.Id("sm"));
            var calculateTheAmountOfCalories = _driver.FindElement(By.Id("submit"));

            age.SendKeys("35");
            weight.SendKeys("85");
            height.SendKeys("185");
            calculateTheAmountOfCalories.Click();

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            var result =
                wait.Until(driver =>
                    driver.FindElement(
                        By.XPath("((//*[@class='res_row'])[2])/td")));

            Assert.AreEqual("3028 ккал/день", result.Text);
        }

        [Test]
        public void Test2()
        {
            _driver.Navigate().GoToUrl(@"https://calc.by/building-calculators/laminate.html");

            var layingMethod = new SelectElement(_driver.FindElement(By.Id("laying_method_laminate")));

            var roomLength = _driver.FindElement(By.Id("ln_room_id"));
            var roomWidth = _driver.FindElement(By.Id("wd_room_id"));
            var laminatePanelLength = _driver.FindElement(By.Id("ln_lam_id"));
            var laminatePanelWidth = _driver.FindElement(By.Id("wd_lam_id"));
            var buttonCalculate = _driver.FindElement(By.XPath("//*[text()='Рассчитать']"));
            var layingDirection = _driver.FindElement(By.Id("direction-laminate-id1"));

            roomLength.Clear();
            roomLength.SendKeys("500");
            roomWidth.Clear();
            roomWidth.SendKeys("400");
            laminatePanelLength.Clear();
            laminatePanelLength.SendKeys("2000");
            laminatePanelWidth.Clear();
            laminatePanelWidth.SendKeys("200");
            layingMethod.SelectByText("с использованием отрезанного элемента");
            layingDirection.Click();
            buttonCalculate.Click();

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            var boardsNumber = wait.Until(driver => driver.FindElement(By.XPath(
                "//*[@class='calc-result']//div[text()[normalize-space()='Требуемое количество досок ламината:']]/span")));

            var packagesNumber = wait.Until(driver => driver.FindElement(By.XPath(
                "//*[@class='calc-result']//*[text()[normalize-space()='Количество упаковок ламината:']]/span")));

            Assert.AreEqual("53", boardsNumber.Text);
            Assert.AreEqual("7", packagesNumber.Text);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}