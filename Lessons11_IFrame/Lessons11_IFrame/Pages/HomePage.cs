using Lessons11_IFrame.BaseEntities;
using OpenQA.Selenium;

namespace Lessons11_IFrame.Pages
{
    public class HomePage : BasePage
    {
        private static string END_POINT = "";

        public readonly By SearchFieldBy = By.ClassName("fast-search__input");
        public readonly By FrameBy = By.ClassName("modal-iframe");
        public readonly By SearchFieldOfFrameBy = By.ClassName("search__input");
        public readonly By FirstSearchElementBy = By.XPath("(//*[contains(@class,'search__result')]//div[contains(@class,'product__title')])[1]");
        public readonly By SearchCloseButtonBy = By.ClassName("search__close");

        public HomePage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public HomePage(IWebDriver driver) : base(driver, true)
        {
        }

        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl + END_POINT);
        }

        public override bool IsPageOpened()
        {
            return _waitService.GetVisibleElement(SearchFieldBy).Displayed;
        }

        public IWebElement SearchField() => Driver.FindElement(SearchFieldBy);
        
        public IWebElement Frame() => Driver.FindElement(FrameBy);

        public IWebElement SearchFieldOfFrame() => Driver.FindElement(SearchFieldOfFrameBy);

        public IWebElement FirstSearchElement() => Driver.FindElement(FirstSearchElementBy);

        public IWebElement SearchCloseButton() => Driver.FindElement(SearchCloseButtonBy);
    }
}