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
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;

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
            // this.driver = new ChromeDriver();
            this.driver = BrowserHost.Instance.Application.Browser;
            this.wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(300));            
        }

        [TearDown]
        public void CleanUp()
        {
            this.driver.Quit();
        }

        [Test]
        public void CheckSiteLoad()
        {/*
            IWebDriver driver = BrowserHost.Instance.Application.Browser;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(300));
            */
            this.driver.Navigate().GoToUrl(@"http://localhost:60634/Article/List");
            
            var logo = this.wait.Until(w => w.FindElement(By.XPath("/html/body/div[1]/div/div[1]/a")));

            Assert.AreEqual("SOFTUNI BLOG", logo.Text);
        }
        
        [Test]
        public void BlogLogoDisplayedRightMessage()
        {
            var homePage = new HomePage(this.driver);

            PageFactory.InitElements(this.driver, homePage);

            homePage.NavigateTo();

            homePage.AssertLogo();
        }
    }
}