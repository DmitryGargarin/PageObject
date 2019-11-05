using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace TestingPageObject.Pages
{
    class MainPage
    {
        private IWebDriver browser;

        public MainPage(IWebDriver driver)
        {
            browser = driver;
        }
        public void ChangeAppearanceButtonClick()
        {
            browser.FindElement(By.XPath("//html/body/div[2]/header/div/div/div/div[4]/a[3]")).Click();
        }
        public void ChangeFontSize()
        {
            browser.FindElement(By.XPath("//*[@data-control='theme-font-lg']")).Click();
        }
        public void ChangeThemeColor()
        {
            browser.FindElement(By.XPath("//*[@data-control='theme-color-blind']")).Click();
        }
        public SearchPage SearchButtonClick()
        {
            return new SearchPage(browser);
        }
        
    }
}
