using Blog.UI.Tests.Pages.ArticlesDashboard;
using Blog.UI.Tests.Pages.Article.DeleteArticle;
using Blog.UI.Tests.Pages.Article.EditArticle;
using Blog.UI.Tests.Pages.Article.CreateArticle;
using Blog.UI.Tests.Pages.Login;
using Blog.UI.Tests.Pages.RegistrationPage;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Windows.Forms;
using OpenQA.Selenium.Interactions;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using Blog.UI.Tests.Pages.Attributes;
using Blog.UI.Tests.Pages.LoginPage;

namespace Blog.UI.Tests
{
		[TestFixture]
    public class UITests
    {

		IWebDriver driver;
		WebDriverWait wait = new WebDriverWait(BrowserHost.Instance.Application.Browser, TimeSpan.FromSeconds(300));
	
        [SetUp]
        public void Init()
        {
            this.driver = BrowserHost.Instance.Application.Browser;
        }

      // [TearDown]
      // public void CleanUp()
      // {
      //     this.driver.Quit();
      // }

        //Registration method
        public void RegistrationWithNegativeData(string testName, params string[] assert)

        {

            var regPage = new RegistrationPage(driver);
            var user = AccessExcelData.GetRegistrationTestData(testName);

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            var asserter = typeof(RegistrationPageAsserter).GetMethod(user.Asserter);

            int assertLenght = assert.Length;
            if (assertLenght == 1)
            {
                var assertString = String.Concat(assert);

                asserter.Invoke(null, new object[] { regPage, assertString });

            }
            else
            {
                var str = assert;
                asserter.Invoke(null, new object[] { regPage, str });
            }
        }

        //Registration Tests
		[LogResultToFileAttribute]
        [Test, Property("Registration", 1)]
		[Author("Georgi")]
        [TestOf("Registration")]
		
        public void RegistrationWithEmptyFields()
        {

            RegistrationWithNegativeData(TestContext.CurrentContext.Test.MethodName, "The Email field is required.", "The Full Name field is required.", "The Password field is required.");
        }
        
		[LogResultToFileAttribute]
		[Test, Property("Registration", 1)]
		[Author("Georgi")]
        [TestOf("Registration")]
        public void RegistrationWithInvalidEmail()
        {
            RegistrationWithNegativeData(TestContext.CurrentContext.Test.MethodName, "The Email field is not a valid e-mail address.");


        }
		
        [LogResultToFileAttribute]
        [Test, Property("Registration", 1)]
		[Author("Georgi")]
        [TestOf("Registration")]
        public void RegistrationWithoutPassword()
        {

            RegistrationWithNegativeData(TestContext.CurrentContext.Test.MethodName, "The Password field is required.");

        }

		[LogResultToFileAttribute]
        [Test, Property("Registration", 1)]
		[Author("Georgi")]
        [TestOf("Registration")]
        public void RegistrationWithoutConfirmPassword()
        {
            RegistrationWithNegativeData(TestContext.CurrentContext.Test.MethodName, "The password and confirmation password do not match.");

        }

		[LogResultToFileAttribute]
        [Test, Property("Registration", 1)]
		[Author("Georgi")]
        [TestOf("Registration")]
        public void RegistrationWithoutEmail()
        {
            RegistrationWithNegativeData(TestContext.CurrentContext.Test.MethodName, "The Email field is required.");

        }


        

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
            dash.AssertNewArticle("qwerty", "browser");
            dash.AssertAuthorSign("--author");
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
            dash.AssertNewArticle("qwertyQWERTYqwertyQWERTYqwertyQWERTYqwertyQWERTY", "browserBROWSERbrowserBROWSERbrowserBROWSERbrowserBROWSERbrowserBROWSERbrowserBROWSERbrowserBROWSERbrowserBROWSERbrowserBROWSERbrowserBROWSER");

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
            ArticlesDashboard dash = new ArticlesDashboard(this.driver);
            dash.AssertPageUrl();
            dash.AssertAvailableCreateButton();
            dash.AssertAvailableLogOutButton();
            dash.AssertAvailableManageUserButton();
            dash.AssertFunctionalMenuButtons();
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
           
            CreateArticle newArticle = new CreateArticle(this.driver);
            newArticle.ArticleNavigateTo();
            newArticle.ArticleCreate("qwerty", "browser");
            ArticlesDashboard dash = new ArticlesDashboard(this.driver);
            dash.AssertAuthorSign("--author");
        }

        [Test]
        [Author("Petya")]
        [TestOf("Articles' Dashboard")]

        public void ArticleDetailsDashboard()
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

            var reminder = this.wait.Until(w => w.FindElement(By.CssSelector("body > div.container.body-content > div > div")));
            List<IWebElement> list = reminder.FindElements(By.TagName("a")).ToList();
            int ArticleId = list.Count;
            IWebElement foundArticle = list[list.Count - 1];
            foundArticle.Click();
            
            dash.AssertArticleDetailsView(ArticleId, "qwerty", "browser", "--author");            
        }
        
        [Test]
        [Author("Petya")]
        [TestOf("Articles' Dashboard")]

        public void ArticleViewEditButtonDashboard()
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

            var reminder = this.wait.Until(w => w.FindElement(By.CssSelector("body > div.container.body-content > div > div")));
            List<IWebElement> list = reminder.FindElements(By.TagName("a")).ToList();
            int ArticleId = list.Count;
            IWebElement foundArticle = list[list.Count - 1];
            foundArticle.Click();
            dash.EditButton.Click();
            EditArticle editArticle = new EditArticle(this.driver);
            editArticle.ArticleEdit("qwerty Update", "browser Update");
            dash.AssertArticleDetailsDashboard(ArticleId,"qwerty Update", "browser Update","--author");           
        }
        
        [Test]
        [Author("Petya")]
        [TestOf("Articles' Dashboard")]

        public void ArticleViewDeleteButtonDashboard()
        {
            this.driver.Manage().Window.Maximize();
            this.driver.Navigate().GoToUrl(BrowserHost.RootUrl);
            Login loginuser = new Login(this.driver);
            loginuser.LoginUser("nikolova.petq@gmail.com", "P@ssw@rd");
            loginuser.AssertLoginUser();

            CreateArticle newArticle = new CreateArticle(this.driver);
            newArticle.ArticleNavigateTo();
            newArticle.ArticleCreate("qwertyPetya", "browserPetya");
            ArticlesDashboard dash = new ArticlesDashboard(this.driver);

            var reminder = this.wait.Until(w => w.FindElement(By.CssSelector("body > div.container.body-content > div > div")));
            List<IWebElement> list = reminder.FindElements(By.TagName("a")).ToList();
            
            IWebElement foundArticle = list[list.Count - 1];
            foundArticle.Click();            
            DeleteArticle deleteArticle = new DeleteArticle(this.driver);
            deleteArticle.ArticleDeletefromList("qwertyPetya");
            dash.AssertCancelArticle("qwertyPetya");

        }
        
        [Test]
        [Author("Petya")]
        [TestOf("Articles' Dashboard")]

        public void ArticleViewBackButtonDashboard()
        {
            this.driver.Manage().Window.Maximize();
            this.driver.Navigate().GoToUrl(BrowserHost.RootUrl);
            Login loginuser = new Login(this.driver);
            loginuser.LoginUser("nikolova.petq@gmail.com", "P@ssw@rd");
            loginuser.AssertLoginUser();
            
            ArticlesDashboard dash = new ArticlesDashboard(this.driver);

            var reminder = this.wait.Until(w => w.FindElement(By.CssSelector("body > div.container.body-content > div > div")));
            List<IWebElement> list = reminder.FindElements(By.TagName("a")).ToList();

            IWebElement foundArticle = list[list.Count - 1];
            foundArticle.Click();
            dash.BackButton.Click();
            dash.AssertPageUrl();
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
            loginuser.AssertPageUrl();
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
            Thread.Sleep(10000);
            Login loginuser = new Login(this.driver);
            loginuser.AssertPageUrl();
        }
		
		[Test]
        [Author("Daniela Stefanova")]
		[TestOf("Login")]
        public void SuccessfulLoginTest()
        {
            var logPage = new LoginPage(this.driver);
            logPage.NavigateTo();
            logPage.LoginButtonClick();

            LoginUser logUser = new LoginUser("daniela_popovo@abv.bg", "123456");
            logPage.FillLoginForm(logUser);

            logPage.SuccessfulLogin("Create\r\nHello daniela_popovo@abv.bg!\r\nLog off");
        }

        [Test]
        [Author("Daniela Stefanova")]
		[TestOf("Login")]
        public void LoginWithoutEmail()
        {
            var logPage = new LoginPage(this.driver);
            logPage.NavigateTo();
            logPage.LoginButtonClick();

            LoginUser logUser = new LoginUser("", "123456");
            logPage.FillLoginForm(logUser);

            logPage.AssertLoginFormEmailError("The Email field is required.");
        }

        [Test]
        [Author("Daniela Stefanova")]
		[TestOf("Login")]
        public void LoginWithoutPassword()
        {
            var logPage = new LoginPage(this.driver);
            logPage.NavigateTo();
            logPage.LoginButtonClick();

            LoginUser logUser = new LoginUser("daniela_popovo@abv.bg", "");
            logPage.FillLoginForm(logUser);

            logPage.AssertLoginFormPasswordError("The Password field is required.");
        }

        [Test]
        [Author("Daniela Stefanova")]
		[TestOf("Login")]
        public void LoginWithoutEmailAndPassword()
        {
            var logPage = new LoginPage(this.driver);
            logPage.NavigateTo();
            logPage.LoginButtonClick();

            LoginUser logUser = new LoginUser("", "");
            logPage.FillLoginForm(logUser);

            logPage.AssertLoginFormEmailError("The Email field is required.");
            logPage.AssertLoginFormPasswordError("The Password field is required.");
        }

        [Test]
        [Author("Daniela Stefanova")]
		[TestOf("Login")]
        public void LoginWithInvalidPassword()
        {
            var logPage = new LoginPage(this.driver);
            logPage.NavigateTo();
            logPage.LoginButtonClick();

            LoginUser logUser = new LoginUser("daniela_popovo@abv.bg", "daniela123456");
            logPage.FillLoginForm(logUser);

            logPage.AssertInvalidPasswordError("Invalid login attempt.");
        }

        [Test]
        [Author("Daniela Stefanova")]
		[TestOf("Login")]
        public void LoginWithInvalidEmail()
        {
            var logPage = new LoginPage(this.driver);
            logPage.NavigateTo();
            logPage.LoginButtonClick();

            LoginUser logUser = new LoginUser("daniela.daniela@google.tc", "123456");
            logPage.FillLoginForm(logUser);

            logPage.AssertInvalidEmailError("Invalid login attempt.");
        }
    }
}
