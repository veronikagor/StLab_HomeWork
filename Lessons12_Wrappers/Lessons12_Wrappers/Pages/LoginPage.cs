using Lessons12_Wrappers.BaseEntities;
using Lessons12_Wrappers.Core.Wrappers;
using OpenQA.Selenium;

namespace Lessons12_Wrappers.Pages
{
    public class LoginPage : BasePage
    {
        private static string END_POINT = "";
        private static readonly By EmailInputBy = By.Id("name");
        private static readonly By PasswordInputBy = By.Id("password");
        private static readonly By RememberMeCheckboxBy = By.Id("rememberme");
        private static readonly By LoginInButtonBy = By.Id("button_primary");

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
            return LoginIn().Displayed;
        }

        public TextBox Email() => new TextBox(Driver, EmailInputBy);

        public TextBox Password() => new TextBox(Driver, PasswordInputBy);

        public CheckBox RememberMe() => new CheckBox(Driver, RememberMeCheckboxBy);

        public Button LoginIn() => new Button(Driver, LoginInButtonBy);
    }
}