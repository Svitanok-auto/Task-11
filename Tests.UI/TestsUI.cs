using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Pages;

namespace Tests.UI
{
    public class TestsUI
    {
        private IWebDriver _driver;
        [OneTimeSetUp]
        public void Init()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://www.gismeteo.ua/");
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            _driver.Close();
            _driver.Quit();
        }

        [Test, Order(1)]
        [Category("UI")]
        public void UITestDiv()
        {
            var mainPage = new MainPage(_driver);
            Assert.AreEqual(279, mainPage.GetDivElements().Count);
        }

        [Test, Order(2)]
        [Category("UI")]
        public void UITestDivH1()
        {
            var mainPage = new MainPage(_driver);
            Assert.AreEqual(1, mainPage.GetDivH1Elements().Count);
        }

        [Test, Order(3)]
        [Category("UI")]
        public void GetNewsElements()
        {
            var mainPage = new MainPage(_driver);
            Assert.AreEqual(4, mainPage.GetNewsElements().Count);
        }

        [Test, Order(4)]
        [Category("UI")]
        public void GetSpanElements()
        {
            var mainPage = new MainPage(_driver);
            Assert.AreEqual("Чернигов", mainPage.GetSpanElement().Text);
        }

        [Test, Order(5)]
        [Category("UI")]
        public void GetNewsElementsTitles()
        {
            var mainPage = new MainPage(_driver);
            Assert.AreEqual(4, mainPage.GetNewsElementsTitles().Count);
        }

        [Test, Order(6)]
        [Category("UI")]
        public void GetElementsWithKyivTitle()
        {
            var mainPage = new MainPage(_driver);
            Assert.IsTrue(mainPage.GetElementsWithKyivTitle().Text == "Киев");
        }

        [Test, Order(7)]
        [Category("UI")]
        public void GetElementAfterKyiv()
        {
            var mainPage = new MainPage(_driver);
            Assert.AreEqual("Кривой Рог", mainPage.GetElementAfterKyiv());
        }

        [Test, Order(8)]
        [Category("UI")]
        public void GetTopMenuLinks()
        {
            var mainPage = new MainPage(_driver);
            Assert.AreEqual(4, mainPage.GetTopMenuLinks().Count);
        }

        [Test, Order(9)]
        [Category("UI")]
        public void Get3DaysWeather()
        {
            var mainPage = new MainPage(_driver);
            Assert.AreEqual(mainPage.Get3DaysWeather().Text, "3 дня");
        }

        [Test, Order(10)]
        [Category("UI")]
        public void GetTodaySelection()
        {
            var mainPage = new MainPage(_driver);
            Assert.IsTrue(mainPage.GetTodaySelection());
        }

        [Test, Order(15)]
        [Category("UI")]
        public void GetLowHighTemperature()
        {
            var mainPage = new MainPage(_driver);
            Assert.AreEqual(2, mainPage.GetLowHighTemperature().Count);
        }

        [Test, Order(11)]
        [Category("UI")]
        public void UITestDivCss()
        {
            var mainPage = new MainPage(_driver);
            Assert.AreEqual(279, mainPage.GetDivElementsCss().Count);
        }

        [Test, Order(12)]
        [Category("UI")]
        public void UITestDivH1Css()
        {
            var mainPage = new MainPage(_driver);
            Assert.AreEqual(1, mainPage.GetDivH1ElementsCss().Count);
        }

        [Test, Order(13)]
        [Category("UI")]
        public void GetNewsElementsCss()
        {
            var mainPage = new MainPage(_driver);
            Assert.AreEqual(4, mainPage.GetNewsElementsCss().Count);
        }

        [Test, Order(14)]
        [Category("UI")]
        public void GetElementsWithKyivTitleCss()
        {
            var mainPage = new MainPage(_driver);
            Assert.IsTrue(mainPage.GetElementsWithKyivTitleCSS());
        }
    }
}
