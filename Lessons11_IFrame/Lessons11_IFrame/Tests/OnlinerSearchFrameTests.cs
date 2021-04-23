using Lessons11_IFrame.BaseEntities;
using Lessons11_IFrame.Pages;
using Lessons11_IFrame.TestData;
using NUnit.Framework;

namespace Lessons11_IFrame.Tests
{
    public class OnlinerSearchFrameTests : BaseTest
    {
        [Test]
        [TestCaseSource(typeof(Data), nameof(Data.DesiredProduct))]
        public void GetSearchResultTest(string product)
        {
            var onlinePage = new HomePage(Driver, true);
            onlinePage.SearchField().SendKeys(product);

            var frame = _waitService.GetVisibleElement(onlinePage.FrameBy);
            Driver.SwitchTo().Frame(frame);

            var firstElement = _waitService.GetVisibleElement(onlinePage.FirstSearchElementBy);
            var text = firstElement.Text;

            onlinePage.SearchFieldOfFrame().Clear();
            onlinePage.SearchFieldOfFrame().SendKeys(text);
            onlinePage.SearchCloseButton().Click();
        }
    }
}