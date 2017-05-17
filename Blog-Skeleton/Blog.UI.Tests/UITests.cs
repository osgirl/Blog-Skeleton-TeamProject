using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.UI.Tests.Pages.HomePage;

namespace Blog.UI.Tests
{
    [TestFixture]
    public class UITests
    {
        IWebDriver driver;
        WebDriverWait wait;

        [SetUp]
        public void Init()
        {
            this.driver = new ChromeDriver();
            this.wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(300));
        }

        [TearDown]
        public void CleanUp()
        {
            this.driver.Quit();
        }

        [Test]
        public void CheckSiteLoad()
        {
            this.driver.Navigate().GoToUrl(@"http://localhost:60634/Article/List");

            var logo = this.wait.Until(w => w.FindElement(By.XPath("/html/body/div[1]/div/div[1]/a")));

            Assert.AreEqual("SOFTUNI BLOG", logo.Text);
        }
        
        [Test]
        public void BlogLogoDisplayedRightMessage()
        {
            var homePage = new HomePage(BrowserHost.Instance.Application.Browser);

            homePage.NavigateTo();

            homePage.AssertLogo();
        }
    }
}
