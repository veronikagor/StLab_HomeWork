using System;
using Lessons8_PageObject.BaseEntities;
using Lessons8_PageObject.Core.Wrappers;
using OpenQA.Selenium;

namespace Lessons8_PageObject.Pages
{
    public class LoginPage : BasePage
    {
        private static string END_POINT = "";

        private static readonly By UserNameBy = By.Id("user-name");
        private static readonly By PasswordBy = By.Id("password");
        private static readonly By LoginInButtonBy = By.Id("login-button");

        public LoginPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public LoginPage(IWebDriver driver) : base(driver, false)
        {
        }

        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseUrl + END_POINT);
        }

        public override bool IsPageOpened()
        {
            return _waitService.GetVisibleElement(LoginInButtonBy).Displayed;
        }

        public TextBox UserName() => new TextBox(Driver, UserNameBy);

        public TextBox Password() => new TextBox(Driver, PasswordBy);

        public Button LoginIn() => new Button(Driver, LoginInButtonBy);
    }
}