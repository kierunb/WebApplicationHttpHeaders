using System;
using System.Net.Http;
using Xunit;
using FluentAssertions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using AngleSharp;
using System.Linq;

namespace WebApplication.GUITests
{
    public class TestyEndToEnd
    {
        [Fact]
        public async void TestSerwisuRest()
        {
            //var http = new HttpClient();
            //var url = "https://localhost:5001/person/1";

            //var response = http.GetAsync(url).Result;
            //response.StatusCode.Should().Be(200);


            var config = Configuration.Default.WithDefaultLoader();
            var address = "https://en.wikipedia.org/wiki/List_of_The_Big_Bang_Theory_episodes";
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(address);
            var cellSelector = "tr.vevent td:nth-child(3)";
            var cells = document.QuerySelectorAll(cellSelector);
            var titles = cells.Select(m => m.TextContent);
        }

        [Fact]
        public void UserKlikaNaWyszukaj_PokazujeMuSieWyszukiwarka()
        {
            string startUrl = "https://nbp.pl";
            var driver = new ChromeDriver();
            driver.Url = startUrl;

            driver.Navigate();
            driver.Manage().Window.Maximize();
            driver.GetScreenshot().SaveAsFile("screen.png");

            var wyszukajElement = driver.FindElement(By.XPath("/html/body/div[1]/form/div[3]/nav[1]/ul/li[6]/a"));

            wyszukajElement.Click();

            var textBoxWyszukiwarki = driver.FindElement(By.Id("gsc-i-id1"));

            textBoxWyszukiwarki.SendKeys("Duda");

            //textBoxWyszukiwarki.Displayed.Should().Be(true);
        }
    }
}
