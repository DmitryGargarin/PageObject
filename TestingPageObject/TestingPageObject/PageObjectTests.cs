using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TestingPageObject.Pages;


namespace TestingPageObject
{
    [TestFixture]
    public class PageObjectTests
    {
        private IWebDriver browser;
        [SetUp]
        public void OpenBrowserAndGoToWebSite()
        {
            browser = new ChromeDriver();
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(1);
            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl("http://gsv.aero");
        }

        //Тест-кейс №8: Перейти в окно покупки билета через поиск
        //1) Зайти на сайт https://gsv.aero
        //2) Нажать на кнопку лупы в верхней части экрана
        //3) Ввести "Купить билет" в текстовом поле
        //4) Нажать кнопку "Поиск"
        //Фактический результат: список вариантов, подходящие под запрос поиска.
        [Test]
        public void BuyTicketThroughSearchWindow()
        {
            MainPage mainPage = new MainPage(browser);
            SearchPage searchPage = mainPage.SearchButtonClick();
            searchPage.InsertTextInSearchField("Купить билеты");
            new WebDriverWait(browser, TimeSpan.FromSeconds(3));
            searchPage.SearchButtonClick();
            searchPage.GetFirstAnswerAndGoToUrl();
            Assert.IsTrue(browser.Url == "https://gsv.aero/services/booking-tickets/");
        }

        //Тест-кейс №10: Изменить внешний вид сайта
        //1) Зайти на сайт https://gsv.aero
        //2) Нажать на иконку очков в верхней части(рядом с иконкой лупы)
        //3) Выбрать размер шрифта "Большой", изменить цветовую схему на чёрно-белую
        //Фактический результат: сайт сменил цвет с синего на чёрный, шрифт стал больше.
        [Test]
        public void ChangeAppearanceOfWebSite()
        {
            MainPage mainPage = new MainPage(browser);
            mainPage.ChangeAppearanceButtonClick();
            mainPage.ChangeFontSize();
            mainPage.ChangeThemeColor();
            Assert.IsTrue(browser.FindElement(By.TagName("html")).GetAttribute("class").Contains("theme-font-lg theme-color-blind"));
        }
        [TearDown]
        public void CloseBrowser()
        {
            browser.Quit();
        }
    }
}
