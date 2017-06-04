﻿using Blog.UI.Tests.Pages.ArticlesDashboard;
using Blog.UI.Tests.Pages.Article.DeleteArticle;
using Blog.UI.Tests.Pages.Article.EditArticle;
using Blog.UI.Tests.Pages.Article.CreateArticle;
using Blog.UI.Tests.Pages.Login;
using Blog.UI.Tests.Pages.RegisterUser;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Windows.Forms;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace Blog.UI.Tests
{
    [TestFixture]
    public class UITests
    {
        IWebDriver driver = BrowserHost.Instance.Application.Browser;
        WebDriverWait wait = new WebDriverWait(BrowserHost.Instance.Application.Browser, TimeSpan.FromSeconds(300));

        [Test]
        [Author("Petya")]
        [TestOf("Navigation")]

        public void CheckSiteLoad()
        {
            this.driver.Manage().Window.Maximize();
            this.driver.Navigate().GoToUrl(BrowserHost.RootUrl);

            var logo = this.wait.Until(w => w.FindElement(By.XPath("/html/body/div[1]/div/div[1]/a")));

            Assert.AreEqual("SOFTUNI BLOG", logo.Text);
        }

        [Test]
        [Author("Petya")]
        [TestOf("Articles' Dashboard")]

        public void FindArticleInDashboard()
        {
            this.driver.Manage().Window.Maximize();
            this.driver.Navigate().GoToUrl(BrowserHost.RootUrl);
            Login loginuser = new Login(this.driver);
            loginuser.LoginUser("nikolova.petq@gmail.com", "P@ssw@rd");
            loginuser.AssertLoginUser();
            CreateArticle newArticle = new CreateArticle(this.driver);
            newArticle.ArticleNavigateTo();
            newArticle.ArticleCreate("qwerty", "browser");
            ArticlesDashboard dash = new ArticlesDashboard(this.driver);
            dash.AssertNewArticle("qwerty");
        }

        [Test]
        [Author("Petya")]
        [TestOf("Articles' Dashboard")]

        public void AvailableScrollBarDashboard()
        {
            this.driver.Manage().Window.Maximize();
            this.driver.Navigate().GoToUrl(BrowserHost.RootUrl);
            Thread.Sleep(10000);
            /*
            RegisterUser newUser = new RegisterUser(this.driver);
            newUser.RegisterUserNavigateTo();
            newUser.RegisterationOfUser("nikolova.petq@gmail.com", "Petya Nikolova", "P@ssw@rd");            
            newUser.AssertNewUser("nikolova.petq@gmail.com");
            */
            Login loginuser = new Login(this.driver);
            loginuser.LoginUser("nikolova.petq@gmail.com", "P@ssw@rd");
            loginuser.AssertLoginUser();
            CreateArticle newArticle = new CreateArticle(this.driver);
            newArticle.ArticleNavigateTo();
            newArticle.ArticleCreate("qwertyQWERTYqwertyQWERTYqwertyQWERTYqwertyQWERTY", "browserBROWSERbrowserBROWSERbrowserBROWSERbrowserBROWSERbrowserBROWSERbrowserBROWSERbrowserBROWSERbrowserBROWSERbrowserBROWSERbrowserBROWSER");
            ArticlesDashboard dash = new ArticlesDashboard(this.driver);
            dash.AssertNewArticle("qwertyQWERTYqwertyQWERTYqwertyQWERTYqwertyQWERTY");

            IJavaScriptExecutor javascript = (IJavaScriptExecutor)this.driver;
            Boolean horzscrollStatus = (Boolean)javascript.ExecuteScript("return document.documentElement.scrollWidth>document.documentElement.clientWidth;");
            Boolean VertscrollStatus = (Boolean)javascript.ExecuteScript("return document.documentElement.scrollHeight>document.documentElement.clientHeight;");

            if (VertscrollStatus & horzscrollStatus)
            {
                dash.log.Info("Both Scroll bars are shown.");
                Assert.Pass("Both Scroll bars are shown.");
            }
            else if (horzscrollStatus)
            {
                dash.log.Info("Horizontal Scroll bars are shown.");
                Assert.Pass("HorizontalScroll bars are shown.");
            }
            else if(VertscrollStatus)
            {
                dash.log.Info("Vertical scroll bars are shown.");
                Assert.Fail("Vertical scroll bars are shown.");
            }
            else
            {
                dash.log.Info("No scroll bars are shown.");
                Assert.Fail("No scroll bars are shown.");
            }            
        }


        [Test]
        [Author("Petya")]
        [TestOf("Articles' Dashboard")]

        public void AvailableButtonsInDashboard()
        {           
            this.driver.Manage().Window.Maximize();
            this.driver.Navigate().GoToUrl(BrowserHost.RootUrl);
            Login loginuser = new Login(this.driver);
            loginuser.LoginUser("nikolova.petq@gmail.com", "P@ssw@rd");
            loginuser.AssertLoginUser();            
            CreateArticle newArticle = new CreateArticle(this.driver);
            newArticle.ArticleNavigateTo();
            newArticle.ArticleCreate("qwerty", "browser");
            ArticlesDashboard dash = new ArticlesDashboard(this.driver);
            dash.AssertPageUrl();
            dash.AssertAvailableCreateButton();
            dash.AssertAvailableLogOutButton();
            dash.AssertAvailableManageUserButton();
        }

        [Test]
        [Author("Petya")]
        [TestOf("Articles' Dashboard")]

        public void SignAuthorInDashboard()
        {            
            this.driver.Manage().Window.Maximize();
            this.driver.Navigate().GoToUrl(BrowserHost.RootUrl);
            Login loginuser = new Login(this.driver);
            loginuser.LoginUser("nikolova.petq@gmail.com", "P@ssw@rd");
            loginuser.AssertLoginUser();
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            CreateArticle newArticle = new CreateArticle(this.driver);
            newArticle.ArticleNavigateTo();
            newArticle.ArticleCreate("qwerty", "browser");
            ArticlesDashboard dash = new ArticlesDashboard(this.driver);
            dash.AssertAuthorSign();
        }


        [Test, Property("Priority", 1)] //asserter added
        [Author("Nury")]
        public void CreateArticleWithoutTittle()
        {
            this.driver.Manage().Window.Maximize();
            this.driver.Navigate().GoToUrl(BrowserHost.RootUrl);

            Login loginuser = new Login(this.driver);
            loginuser.LoginUser("londa101@abv.bg", "londa101");

            CreateArticle newArticle = new CreateArticle(this.driver);
            newArticle.ArticleNavigateTo();
            newArticle.ArticleCreate("", "This is the text of article THREE");
            newArticle.AssertTitleErrorMessage("The Title field is required.");
        }

        [Test, Property("Priority", 1)]  //asserter added
        [Author("Nury")]
        public void CreateArticleWithLongTittle()
        {
            this.driver.Manage().Window.Maximize();
            this.driver.Navigate().GoToUrl(BrowserHost.RootUrl);

            Login loginuser = new Login(this.driver);
            loginuser.LoginUser("londa101@abv.bg", "londa101");

            CreateArticle newArticle = new CreateArticle(this.driver);
            newArticle.ArticleNavigateTo();
            newArticle.ArticleCreate("Article Test more than 50. Article Test more than 50.", "Thisi is the text of article test");
            newArticle.AssertTitleErrorMessage("The field Title must be a string with a maximum length of 50.");
        }

        [Test, Property("Priority", 1)] //asserter added
        [Author("Nury")]
        public void CreateArticleWithoutContent()
        {
            this.driver.Manage().Window.Maximize();
            this.driver.Navigate().GoToUrl(BrowserHost.RootUrl);

            Login loginuser = new Login(this.driver);
            loginuser.LoginUser("londa101@abv.bg", "londa101");

            CreateArticle newArticle = new CreateArticle(this.driver);
            newArticle.ArticleNavigateTo();
            newArticle.ArticleCreate("Article Test THREE", "");
            newArticle.AssertContentErrorMessage("The Content field is required.");
        }

    [Test, Property("Priority", 1)] //!!!!!!!
        [Author("Nury")]
        public void CreateArticleWithoutSubmit()
        {
            this.driver.Manage().Window.Maximize();
            this.driver.Navigate().GoToUrl(BrowserHost.RootUrl);

            Login loginuser = new Login(this.driver);
            loginuser.LoginUser("londa101@abv.bg", "londa101");

            CreateArticle newArticle = new CreateArticle(this.driver);
            newArticle.ArticleNavigateTo();
            newArticle.AssertCancelButtonDesplayed();
            newArticle.ArticleCreateWithoutSubmit("Title CancelButton", "Content CancelButton");
           
            ArticlesDashboard dash = new ArticlesDashboard(this.driver);
            dash.AssertCancelArticle("Article Test Nury");


        }

        [Test, Property("Priority", 1)] //!!!asserter is not added
        [Author("Nury")]
        public void EditOwnArticleFromList()
        {
            this.driver.Manage().Window.Maximize();
            this.driver.Navigate().GoToUrl(BrowserHost.RootUrl);

            Login loginuser = new Login(this.driver);
            loginuser.LoginUser("londa101@abv.bg", "londa101");

            ArticlesDashboard dash = new ArticlesDashboard(this.driver);
            EditArticle newEditArticle = new EditArticle(this.driver);

            newEditArticle.ArticleEdit("Article Test Nury3", "Thisi is the text of article Nury3");
        }


        [Test, Property("Priority", 1)] //!!!!! asserter not added
        [Author("Nury")]

        public void EditArticleFromListWhitoutLogin()
        {
            this.driver.Manage().Window.Maximize();
            this.driver.Navigate().GoToUrl(BrowserHost.RootUrl);

            EditArticle newEditArticle = new EditArticle(this.driver);
            newEditArticle.AssertEditButtonDesplayed();
            newEditArticle.ArticleEditButton();
            Login loginuser = new Login(this.driver);
        }


        [Test, Property("Priority", 1)] ////!!!!! asserter not added
        [Author("Nury")]
        public void DeleteOwnArticleFromList()
        {
            this.driver.Manage().Window.Maximize();
            this.driver.Navigate().GoToUrl(BrowserHost.RootUrl);

            Login loginuser = new Login(this.driver);
            loginuser.LoginUser("londa101@abv.bg", "londa101");

            DeleteArticle newDeleteArticle = new DeleteArticle(this.driver);
            newDeleteArticle.AssertDeleteButtonDisplayed();
            newDeleteArticle.ArticleDeletefromList("Article Test THREE");
        }

        [Test, Property("Priority", 1)] //asserter added
        [Author("Nury")]
        public void DeleteArticleFromListWithoutLogin()
        {
            this.driver.Manage().Window.Maximize();
            this.driver.Navigate().GoToUrl(BrowserHost.RootUrl);

            DeleteArticle newDeleteArticle = new DeleteArticle(this.driver);
            newDeleteArticle.ArticleDeletefromList("qwerty"); 
            newDeleteArticle.ArticleDeleteButton();
            Thread.Sleep(10000);
            Login loginuser = new Login(this.driver);
            loginuser.AssertPageUrl();
        }
    }
}
