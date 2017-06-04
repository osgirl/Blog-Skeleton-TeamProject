using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Blog.UI.Tests
{
    public class BasePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private string url = @"http://localhost:60639/Article/List";
        public readonly log4net.ILog log =
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(60));
        }

        public IWebDriver Driver
        {
            get
            {
                return this.driver;
            }
        }

        public WebDriverWait Wait
        {
            get
            {
                return this.wait;
            }
        }

        public string Url
        {
            get
            {
                return this.url;
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.Url);
        }
    }
}
