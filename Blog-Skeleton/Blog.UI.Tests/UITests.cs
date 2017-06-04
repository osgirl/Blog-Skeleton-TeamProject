using Blog.UI.Tests.Pages.ArticlesDashboard;
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

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(BrowserHost.RootUrl);

            var logo = wait.Until(w => w.FindElement(By.XPath("/html/body/div[1]/div/div[1]/a")));

            Assert.AreEqual("SOFTUNI BLOG", logo.Text);
        }

        [Test]
        public void FindArticleInDashboard()
        {
            IWebDriver driver = BrowserHost.Instance.Application.Browser;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(BrowserHost.RootUrl);
            Login loginuser = new Login(driver);
            loginuser.LoginUser("nikolova.petq@gmail.com", "P@ssw@rd");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            CreateArticle newArticle = new CreateArticle(driver);
            newArticle.ArticleNavigateTo();
            newArticle.ArticleCreate("qwerty", "browser");
            ArticlesDashboard dash = new ArticlesDashboard(driver);
            dash.AssertNewArticle("qwerty");
        }

        [Test]
        public void AvailableScrollBarDashboard()
        {
            IWebDriver driver = BrowserHost.Instance.Application.Browser;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(BrowserHost.RootUrl);

            //RegisterUser newUser = new RegisterUser(driver);
            //newUser.RegisterUserNavigateTo();
            //newUser.RegisterationOfUser("nikolova.petq@gmail.com", "Petya Nikolova", "P@ssw@rd", "P@ssw@rd");
            //newUser.AssertNewUser("nikolova.petq@gmail.com");

            Login loginuser = new Login(driver);
            loginuser.LoginUser("nikolova.petq@gmail.com", "P@ssw@rd");
            CreateArticle newArticle = new CreateArticle(driver);

            newArticle.ArticleNavigateTo();
            newArticle.ArticleCreate("qwertyQWERTYqwerty", "BROWSERbrowserBROWSER browserBROWSERbrowserBROWSE RbrowserBROWSERbrowserBROWSERbrowser BROWSERbrowserBROWSER");
            ArticlesDashboard dash = new ArticlesDashboard(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            dash.AssertNewArticle("qwertyQWERTYqwertyQWERTYqwertyQWERTYqwertyQWERTY");
            ScrollableControl ctl = new ScrollableControl();
            ScrollBars scroll = dash.GetVisibleScrollbars(ctl);

            if (scroll.Equals(ScrollBars.None))
            {
                dash.log.Info("No scroll bars are shown.");
                Assert.Fail();
            }
            else if (scroll.Equals(ScrollBars.Both))
            {
                dash.log.Info("Both horizontal and vertical scroll bars are shown.");
                Assert.Pass();
            }
            else if (scroll.Equals(ScrollBars.Horizontal))
            {
                dash.log.Info("Only horizontal scroll bars are shown.");
                Assert.Fail();
            }
            else if (scroll.Equals(ScrollBars.Vertical))
            {
                dash.log.Info("Only vertical scroll bars are shown.");
                Assert.Fail();
            }
        }

     
        [Test, Property("Priority", 1)] //asserter added
        [Author("Nury")]
        public void CreateArticleWithoutTittle()
        {
            IWebDriver driver = BrowserHost.Instance.Application.Browser;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(BrowserHost.RootUrl);

            Login loginuser = new Login(driver);
            loginuser.LoginUser("londa101@abv.bg", "londa101");

            CreateArticle newArticle = new CreateArticle(driver);
            newArticle.ArticleNavigateTo();
            newArticle.ArticleCreate("", "Thisi is the text of article THREE");
            newArticle.AssertTitleErrorMessage("The Title field is required.");
         }

        [Test, Property("Priority", 1)]  //asserter added
        [Author("Nury")]
        public void CreateArticleWithLongTittle()
        {
            IWebDriver driver = BrowserHost.Instance.Application.Browser;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(BrowserHost.RootUrl);

            Login loginuser = new Login(driver);
            loginuser.LoginUser("londa101@abv.bg", "londa101");

            CreateArticle newArticle = new CreateArticle(driver);
            newArticle.ArticleNavigateTo();
            newArticle.ArticleCreate("Article Test more than 50. Article Test more than 50.", "Thisi is the text of article test");
            newArticle.AssertTitleErrorMessage("The field Title must be a string with a maximum length of 50.");
        }

        [Test, Property("Priority", 1)] //asserter added
        [Author("Nury")]
        public void CreateArticleWithoutContent()
        {
            IWebDriver driver = BrowserHost.Instance.Application.Browser;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(BrowserHost.RootUrl);

            Login loginuser = new Login(driver);
            loginuser.LoginUser("londa101@abv.bg", "londa101");

            CreateArticle newArticle = new CreateArticle(driver);
            newArticle.ArticleNavigateTo();
            newArticle.ArticleCreate("Article Test THREE", "");
            newArticle.AssertContentErrorMessage("The Content field is required.");
        }

        [Test, Property("Priority", 1)] //is not working
        [Author("Nury")]
        public void CreateArticleWithoutSubmit()
        {
            IWebDriver driver = BrowserHost.Instance.Application.Browser;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(BrowserHost.RootUrl);

            Login loginuser = new Login(driver);
            loginuser.LoginUser("londa101@abv.bg", "londa101");

            CreateArticle newArticle = new CreateArticle(driver);
            newArticle.ArticleNavigateTo();
            newArticle.AssertCancelButtonDesplayed();
            newArticle.ArticleCreateWithoutSubmit("Title CancelButton", "Content CancelButton");
            //това не работи
            //ArticlesDashboard dash = new ArticlesDashboard(driver);
            //dash.AssertNewArticle("Title CancelButton");

            
        }
        
        [Test, Property("Priority", 1)] //is not working
        [Author("Nury")]
        public void EditOwnArticleFromList()
        {
            IWebDriver driver = BrowserHost.Instance.Application.Browser;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(BrowserHost.RootUrl);

            Login loginuser = new Login(driver);
            loginuser.LoginUser("londa101@abv.bg", "londa101");

            ArticlesDashboard dash = new ArticlesDashboard(driver);
            EditArticle newEditArticle = new EditArticle(driver);

            newEditArticle.ArticleEdit("Article Test Nury", "Thisi is the text of article Nury");
        }


        [Test, Property("Priority", 1)] //asserter added
        [Author("Nury")]

        public void EditArticleFromListWhitoutLogin()
        {
            IWebDriver driver = BrowserHost.Instance.Application.Browser;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(BrowserHost.RootUrl);

            EditArticle newEditArticle = new EditArticle(driver);
            newEditArticle.AssertEditButtonDesplayed();
            newEditArticle.ArticleEditButton();
            Login loginuser = new Login(driver);
        }


        [Test, Property("Priority", 1)] //asserter added
        [Author("Nury")]
        public void DeleteOwnArticleFromList()
        {
            IWebDriver driver = BrowserHost.Instance.Application.Browser;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(BrowserHost.RootUrl);

            Login loginuser = new Login(driver);
            loginuser.LoginUser("londa101@abv.bg", "londa101");
          
            DeleteArticle newDeleteArticle = new DeleteArticle(driver);
            newDeleteArticle.AssertDeleteButtonDesplayed();
            newDeleteArticle.ArticleDeletefromList("Article Test THREE");
        }

        [Test, Property("Priority", 1)] //asserter added
        [Author("Nury")]
        public void DeleteArticleFromListWhitoutLogin()
        {
            IWebDriver driver = BrowserHost.Instance.Application.Browser;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(BrowserHost.RootUrl);
           
            DeleteArticle newDeleteArticle = new DeleteArticle(driver);
            newDeleteArticle.AssertDeleteButtonDesplayed();
            newDeleteArticle.AssertDeleteInsiteButtonDesplayed();
            newDeleteArticle.ArticleDeleteButton();

            Login loginuser = new Login(driver);
        }


    }
}
