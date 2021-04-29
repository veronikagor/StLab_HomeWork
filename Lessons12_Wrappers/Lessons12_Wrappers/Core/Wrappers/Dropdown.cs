using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace Lessons12_Wrappers.Core.Wrappers
{
    public class Dropdown
    {
        private UIElement _uiElement;
        private static ReadOnlyCollection<IWebElement> options;

        public Dropdown(IWebDriver webDriver, By @by, string dropdownIdName)
        {
            _uiElement = new UIElement(webDriver, @by);
            options = _uiElement.FindElements(By.XPath($"//*[@id='{dropdownIdName}']//a"));
        }

        public void SelectByText(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                bool isElementFound = false;
                var nameOptionsList = new List<string>();

                _uiElement.Click();
                foreach (var option in options)
                {
                    nameOptionsList.Add(option.Text);
                    if (option.Text.Trim() == text.Trim())
                    {
                        option.Click();
                        isElementFound = true;
                        break;
                    }
                }

                if (!isElementFound)
                {
                    throw new NotFoundException(
                        $"Option with label: {text}, was not found, available values: \n{string.Join(",\n", nameOptionsList)}");
                }
            }
            else
            {
                {
                    throw new ArgumentException("The option name must not be blank.");
                }
            }
        }
    }
}