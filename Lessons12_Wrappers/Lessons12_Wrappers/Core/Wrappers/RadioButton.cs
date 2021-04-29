using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Lessons12_Wrappers.Core.Wrappers
{
    public class RadioButton
    {
        private UIElement _uiElement;
        private static ReadOnlyCollection<IWebElement> _radiobuttonList;
        private static string _descriptionTag;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="by"></param>
        /// <param name="descriptionTag">this is the tag on the DOM page that contains the name of radio button</param>
        public RadioButton(IWebDriver webDriver, By @by, string descriptionTag)
        {
            _uiElement = new UIElement(webDriver, @by);
            _descriptionTag = descriptionTag;
            _radiobuttonList = _uiElement.FindElements(by);
        }

        public void Click(string key)
        {
            bool isElementFound = false;
            var radioButtonNamesList = new List<string>();
            foreach (var radioButton in _radiobuttonList)
            {
                var currentElement = radioButton.FindElement(By.XPath($"./../{_descriptionTag}"));
                radioButtonNamesList.Add(currentElement.Text);
                if (currentElement.Text == key)
                {
                    if (!currentElement.Selected)
                    {
                        currentElement.Click();
                    }

                    isElementFound = true;
                    break;
                }
            }

            if (!isElementFound)
            {
                throw new NotFoundException(
                    $"Element with label: {key}, was not found, available values: \n{string.Join(",\n", radioButtonNamesList)}");
            }
        }

        public void ScrollToElement(IWebDriver webDriver, RadioButton radioButton)
        {
            var js = (IJavaScriptExecutor) webDriver;
            try
            {
                js.ExecuteScript("arguments[0].scrollIntoView(true);", radioButton);
            }
            catch (Exception ex)
            {
                throw new AssertionException(ex.Message);
            }
        }
    }
}