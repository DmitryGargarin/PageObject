using NUnit.Framework;
using OpenQA.Selenium;
using System;


namespace TestingPageObject.Pages
{
    class SearchPage
    {
        private IWebDriver browser;
        private IWebElement inputField;
        public SearchPage(IWebDriver driver)
        {
            browser = driver;
            browser.Navigate().GoToUrl(browser.FindElement(By.TagName("body")).FindElement(By.TagName("header")).FindElement(By.ClassName("header-inner"))
              .FindElement(By.ClassName("container")).FindElement(By.ClassName("header-row"))
              .FindElements(By.TagName("div"))[3].FindElements(By.TagName("a"))[1]
              .GetAttribute("href"));
            inputField = browser.FindElement(By.Name("q"));
        }
        public void InsertTextInSearchField(string text)
        {
            inputField.SendKeys(text);
        }
        public void GetFirstAnswerAndGoToUrl()
        {
            browser.Navigate().GoToUrl(browser.FindElement(By.XPath("//a[@class='search-result']")).GetAttribute("href"));
        }
        public void SearchButtonClick()
        {
            browser.FindElement(By.TagName("section")).FindElement(By.ClassName("container"))
                .FindElement(By.TagName("form")).FindElement(By.ClassName("search-btn-shell")).FindElement(By.TagName("button")).Click();

        }
    }
}
