using Blog.UI.Tests.Pages.ArticlesDashboard;
using Blog.UI.Tests.Pages.CreateArticle;
using Blog.UI.Tests.Pages.Login;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests
{
    [TestFixture]
    public class UITests
    {
        [Test]
        public void CheckSiteLoad()
        {
            IWebDriver driver = BrowserHost.Instance.Application.Browser;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(300));


            driver.Navigate().GoToUrl(BrowserHost.RootUrl);

            var logo = wait.Until(w => w.FindElement(By.XPath("/html/body/div[1]/div/div[1]/a")));

            Assert.AreEqual("SOFTUNI BLOG", logo.Text);
        }

        [Test]
        public void FindArticleInDashboard()
        {
            IWebDriver driver = BrowserHost.Instance.Application.Browser;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            
            driver.Navigate().GoToUrl(BrowserHost.RootUrl);
            Login loginuser=new Login(driver);
            loginuser.LoginUser("nikolova.petq@gmail.com", "P@ssw@rd");
            CreateArticle newArticle = new CreateArticle(driver);
            newArticle.NavigateTo();
            newArticle.ArticleCreate("qwerty", "browser");
            ArticlesDashboard dash = new ArticlesDashboard(driver);
            dash.AssertNewArticle("qwerty");
        }
    }
}
