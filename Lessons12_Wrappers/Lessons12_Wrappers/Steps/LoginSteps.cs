using Lessons12_Wrappers.Pages;
using Lessons12_Wrappers.Services;
using OpenQA.Selenium;

namespace Lessons12_Wrappers.Steps
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
            var loginPage = new LoginPage(_driver);

            loginPage.Email().SendKeys(Configurator.UserName);
            loginPage.Password().SendKeys(Configurator.Password);
            loginPage.LoginIn().Click();
        }
    }
}