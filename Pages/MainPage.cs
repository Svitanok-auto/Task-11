using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Pages
{
    public class MainPage
    {
        private static IWebDriver _driver;
        public MainPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public List<IWebElement> GetDivElements()
        {
            List<IWebElement> DivElements = _driver.FindElements(By.TagName("div")).ToList();
            return DivElements;
        }

        public List<IWebElement> GetDivH1Elements()
        {
            List<IWebElement> DivH1Elements = _driver.FindElements(By.XPath(".//div//h1")).ToList();
            return DivH1Elements;
        }

        public List<IWebElement> GetNewsElements()
        {
            List<IWebElement> NewsElements = _driver.FindElements(By.XPath(".//div[@class='readmore_item']")).ToList();
            return NewsElements;
        }

        public IWebElement GetSpanElement()
        {
            IWebElement CityElement = _driver.FindElement(By.XPath(".//div/a/span[@class='cities_name'][text()='Чернигов']"));         
            return CityElement;
        }

        public List<string> GetNewsElementsTitles()
        {
            List<IWebElement> NewsElements = _driver.FindElements(By.XPath(".//div[@class='readmore_item']/div/a/div[starts-with(@style,'back')]")).ToList();
            List<string> elementTitles= new List<string>();
            foreach(IWebElement element in NewsElements)
            {
                elementTitles.Add(element.Text);
            }
            return elementTitles;
        }

        public IWebElement GetElementsWithKyivTitle()
        {
            IWebElement CityElement = _driver.FindElement(By.XPath(".//span[text()='Киев']"));
            return CityElement;
        }

        public string GetElementAfterKyiv()
        {
            IWebElement CityElement = _driver.FindElement(By.XPath(".//div[2]/div[2]/div[8]/a/span[1]"));
            return CityElement.Text;
        }

        public List<IWebElement> GetTopMenuLinks()
        {
            List<IWebElement> MenuElements = _driver.FindElements(By.XPath(".//li[@class='nav_item']/a[@class='link blue']")).ToList();
            return MenuElements;
        }

        public IWebElement Get3DaysWeather()
        {
            IWebElement WeatherElement = _driver.FindElement(By.XPath(".//a[contains(@title,'3 дня')]"));
            return WeatherElement;
        }

        public bool GetTodaySelection()
        {
            IWebElement TodayElement = _driver.FindElement(By.XPath(".//a[@title='Погода в Харькове']"));
            if (TodayElement.Enabled)
            {
                return true;
            }
            return false;
        }

        public List<string> GetLowHighTemperature()
        {
            IWebElement TodayElement = _driver.FindElement(By.XPath(".//a[@title='Погода в Харькове']"));
            TodayElement.Click();
            List<IWebElement> ListElement = _driver.FindElements(By.XPath(".//div/div[@class='tab_wrap']/div[@class = 'tab-content']/div[contains(@class, 'tabtempline tabtemp')]/div/div/div/div/span[contains(@class, 'temperature_c')][1]")).ToList();
            List<string> elementTitles = new List<string>();
            foreach (IWebElement element in ListElement)
            {
                elementTitles.Add(element.Text);
            }
            return elementTitles;
        }

        public List<IWebElement> GetDivElementsCss()
        {
            List<IWebElement> DivElements = _driver.FindElements(By.CssSelector("div")).ToList();
            return DivElements;
        }

        public List<IWebElement> GetDivH1ElementsCss()
        {
            List<IWebElement> DivH1Elements = _driver.FindElements(By.CssSelector("div h1")).ToList();
            return DivH1Elements;
        }

        public List<IWebElement> GetNewsElementsCss()
        {
            List<IWebElement> NewsElements = _driver.FindElements(By.CssSelector(".readmore_item")).ToList();
            return NewsElements;
        }

        public bool GetElementsWithKyivTitleCSS()
        {
            List<IWebElement> CityElements = _driver.FindElements(By.CssSelector("span[class^='cities']")).ToList();
            foreach (IWebElement element in CityElements)
            {
                if (element.Text == "Киев")
                {
                    return true;
                }
            }
            return false;
        }
    }
}
