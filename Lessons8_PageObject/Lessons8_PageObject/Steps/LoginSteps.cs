using Lessons8_PageObject.Pages;
using Lessons8_PageObject.Services;
using OpenQA.Selenium;

namespace Lessons8_PageObject.Steps
{
    public class LoginSteps
    {
        private IWebDriver _driver;

        public LoginSteps(IWebDriver driver)
        {
            _driver = driver;
        }
        
        public void Login()
        {
            LoginPage loginPage = new LoginPage(_driver);

            loginPage.UserName().SendKeys(Configurator.UserName);
            loginPage.Password().SendKeys(Configurator.Password);
            loginPage.LoginIn().Click();
        }
    }
}