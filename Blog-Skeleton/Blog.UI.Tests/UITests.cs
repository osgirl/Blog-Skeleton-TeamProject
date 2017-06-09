using Blog.UI.Tests.Pages.ArticlesDashboard;
using Blog.UI.Tests.Pages.Article.DeleteArticle;
using Blog.UI.Tests.Pages.Article.EditArticle;
using Blog.UI.Tests.Pages.Article.CreateArticle;
using Blog.UI.Tests.Pages.LoginPage;
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
using Blog.UI.Tests.Models;
using Blog.UI.Tests.Pages.RegisterUser;


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
            this.driver = BrowserHost.Instance.Application.Browser;
            this.wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(60));
            this.driver.Manage().Window.Maximize();
            this.driver.Navigate().GoToUrl(BrowserHost.RootUrl);
        }
        /*
        [TearDown]
        public void CleanUp()
        {
            this.driver.Quit();
        }
        */
       /*
        [Test]
        [Author("A-Petya")]
        public void RegistrationTestUsers()
        {
            RegisterUser newUser1 = new RegisterUser(this.driver);
            newUser1.RegisterUserNavigateTo();
            newUser1.RegisterationOfUser("nikolova.petq@gmail.com", "Petya Nikolova", "P@ssw@rd");
            newUser1.AssertNewUser("nikolova.petq@gmail.com");
            
            RegisterUser newUser2 = new RegisterUser(this.driver);
            newUser2.RegisterUserNavigateTo();
            newUser2.RegisterationOfUser("londa101@abv.bg", "londa101", "londa101");
            newUser2.AssertNewUser("londa101@abv.bg");

            RegisterUser newUser3 = new RegisterUser(this.driver);
            newUser3.RegisterUserNavigateTo();
            newUser3.RegisterationOfUser("daniela_popovo@abv.bg", "Daniela", "123456");
            newUser3.AssertNewUser("daniela_popovo@abv.bg");
           
        }
        */

        //Registration method
        [Author("Georgi")]
        public void RegistrationWithNegativeData(string testName, params string[] assert)
        {
            var regPage = new RegistrationPage(this.driver);
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
        [Category("SmokeTests")]

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
            var logo = this.wait.Until(w => w.FindElement(By.XPath("/html/body/div[1]/div/div[1]/a")));
            Assert.AreEqual("SOFTUNI BLOG", logo.Text);
        }

        [Test]
        [Author("Petya")]
        [TestOf("Articles' Dashboard")]

        public void FindArticleInDashboard()
        {            
            LoginPage loginuser = new LoginPage(this.driver);
            loginuser.LoginUser("nikolova.petq@gmail.com", "P@ssw@rd");
            loginuser.AssertLoginUser();
            CreateArticle newArticle = new CreateArticle(this.driver);
            newArticle.ArticleNavigateTo();
            newArticle.ArticleCreate("qwerty", "browser");
            ArticlesDashboard dash = new ArticlesDashboard(this.driver);
            dash.AssertNewArticle("qwerty", "browser");
            dash.AssertAuthorSign("--author");
            dash.LogOut.Click();
        }

        [Test]
        [Author("Petya")]
        [TestOf("Articles' Dashboard")]

        public void AvailableScrollBarDashboard()
        {            
            Thread.Sleep(10000);
            LoginPage loginuser = new LoginPage(this.driver);
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
            dash.LogOut.Click();
        }


        [Test]
        [Author("Petya")]
        [TestOf("Articles' Dashboard")]

        public void AvailableButtonsInDashboard()
        {                       
            LoginPage loginuser = new LoginPage(this.driver);
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
            LoginPage loginuser = new LoginPage(this.driver);
            loginuser.LoginUser("nikolova.petq@gmail.com", "P@ssw@rd");
            loginuser.AssertLoginUser();
           
            CreateArticle newArticle = new CreateArticle(this.driver);
            newArticle.ArticleNavigateTo();
            newArticle.ArticleCreate("qwerty", "browser");
            ArticlesDashboard dash = new ArticlesDashboard(this.driver);
            dash.AssertAuthorSign("--author");
            dash.LogOut.Click();
        }
        
        [Test]
        [Author("Petya")]
        [TestOf("Articles' Dashboard")]

        public void ArticleDetailsDashboard()
        {            
            LoginPage loginuser = new LoginPage(this.driver);
            loginuser.LoginUser("nikolova.petq@gmail.com", "P@ssw@rd");
            loginuser.AssertLoginUser();

            CreateArticle newArticle = new CreateArticle(this.driver);
            newArticle.ArticleNavigateTo();
            newArticle.ArticleCreate("qwerty", "browser");
            ArticlesDashboard dash = new ArticlesDashboard(this.driver);
            string href = dash.FindArticleIdByTitle("qwerty").GetAttribute("href");
            List<string> articleDetails = href.Split('/').ToList();

            int ArticleId = int.Parse(articleDetails[articleDetails.Count-1]);
            dash.FindArticleByTitle("qwerty");           

            dash.AssertArticleDetailsView(ArticleId, "qwerty", "browser", "--author");
            dash.LogOut.Click();
        }
        
        [Test]
        [Author("Petya")]
        [TestOf("Articles' Dashboard")]
        [Category("SmokeTests")]

        public void ArticleViewEditButtonDashboard()
        {            
            LoginPage loginuser = new LoginPage(this.driver);
            loginuser.LoginUser("nikolova.petq@gmail.com", "P@ssw@rd");
            loginuser.AssertLoginUser();

            CreateArticle newArticle = new CreateArticle(this.driver);
            newArticle.ArticleNavigateTo(  );
            newArticle.ArticleCreate("qwerty", "browser");
            ArticlesDashboard dash = new ArticlesDashboard(this.driver);

            EditArticle editArticle = new EditArticle(this.driver);
            IWebElement element = dash.FindArticleIdByTitle("qwerty");
            string href = element.GetAttribute("href");
            List<string> articleDetails = href.Split('/').ToList();
            
            int ArticleId = int.Parse(articleDetails[articleDetails.Count - 1]);
            element.Click();
            editArticle.ArticleEdit("qwerty Update", "browser Update");
            dash.AssertArticleDetailsDashboard(ArticleId,"qwerty Update", "browser Update","--author");
            dash.LogOut.Click();
        }
        
        [Test]
        [Author("Petya")]
        [TestOf("Articles' Dashboard")]

        public void ArticleViewDeleteButtonDashboard()
        {            
            LoginPage loginuser = new LoginPage(this.driver);
            loginuser.LoginUser("nikolova.petq@gmail.com", "P@ssw@rd");
            loginuser.AssertLoginUser();

            CreateArticle newArticle = new CreateArticle(this.driver);
            newArticle.ArticleNavigateTo();
            newArticle.ArticleCreate("qwertyPetya", "browserPetya");
            ArticlesDashboard dash = new ArticlesDashboard(this.driver);
          
            DeleteArticle deleteArticle = new DeleteArticle(this.driver);
            deleteArticle.ArticleDeletefromList("qwertyPetya");
            dash.AssertCancelArticle("qwertyPetya");
            dash.LogOut.Click();
        }
        
        [Test]
        [Author("Petya")]
        [TestOf("Articles' Dashboard")]

        public void ArticleViewBackButtonDashboard()
        {            
            LoginPage loginuser = new LoginPage(this.driver);
            loginuser.LoginUser("nikolova.petq@gmail.com", "P@ssw@rd");
            loginuser.AssertLoginUser();
            
            ArticlesDashboard dash = new ArticlesDashboard(this.driver);

            var reminder = this.wait.Until(w => w.FindElement(By.CssSelector("body > div.container.body-content > div > div")));
            List<IWebElement> list = reminder.FindElements(By.TagName("a")).ToList();

            IWebElement foundArticle = list[list.Count - 1];
            foundArticle.Click();
            dash.BackButtonArticle.Click();
            dash.AssertPageUrl();
            dash.LogOut.Click();
        }

        [Test, Property("Priority", 1)]
        [Author("Nury")]
        [TestOf("Create Article")]

        public void CreateArticle()
        {
            this.driver.Manage().Window.Maximize();
            this.driver.Navigate().GoToUrl(BrowserHost.RootUrl);

            LoginPage loginuser = new LoginPage(this.driver);
            //loginuser.LoginUser("londa101@abv.bg", "londa101");
            loginuser.LoginUser("nikolova.petq@gmail.com", "P@ssw@rd");

            CreateArticle newArticle = new CreateArticle(this.driver);
            newArticle.ArticleNavigateTo();
            newArticle.ArticleCreate("New Article Test One", "Content of article");

            ArticlesDashboard dash = new ArticlesDashboard(this.driver);
            dash.AssertFindArticleDashboard("New Article Test One");
            dash.LogOut.Click();
        }

        [Test, Property("Priority", 1)] 
        [Author("Nury")]

        public void CreateArticleWithoutTittle()
        {
            LoginPage loginuser = new LoginPage(this.driver);
            //loginuser.LoginUser("londa101@abv.bg", "londa101");
            loginuser.LoginUser("nikolova.petq@gmail.com", "P@ssw@rd");

            CreateArticle newArticle = new CreateArticle(this.driver);
            newArticle.ArticleNavigateTo();
            newArticle.ArticleCreate("", "This is the text of article THREE");
            newArticle.AssertTitleErrorMessage("The Title field is required.");
            loginuser.LogOffButton.Click();
        }

        [Test, Property("Priority", 1)]  
        [Author("Nury")]

        public void CreateArticleWithLongTittle()
        {
            LoginPage loginuser = new LoginPage(this.driver);
           // loginuser.LoginUser("londa101@abv.bg", "londa101");
            loginuser.LoginUser("nikolova.petq@gmail.com", "P@ssw@rd");

            CreateArticle newArticle = new CreateArticle(this.driver);
            newArticle.ArticleNavigateTo();
            newArticle.ArticleCreate("Article Test more than 50. Article Test more than 50.", "This is the text of article test");
            newArticle.AssertTitleErrorMessage("The field Title must be a string with a maximum length of 50.");
            loginuser.LogOffButton.Click();
        }

        [Test, Property("Priority", 1)] 
        [Author("Nury")]

        public void CreateArticleWithoutContent()
        {
            LoginPage loginuser = new LoginPage(this.driver);
           // loginuser.LoginUser("londa101@abv.bg", "londa101");
            loginuser.LoginUser("nikolova.petq@gmail.com", "P@ssw@rd");

            CreateArticle newArticle = new CreateArticle(this.driver);
            newArticle.ArticleNavigateTo();
            newArticle.ArticleCreate("Article Test THREE", "");
            newArticle.AssertContentErrorMessage("The Content field is required.");
            loginuser.LogOffButton.Click();
        }

        [Test, Property("Priority", 1)] 
        [Author("Nury")]

        public void CreateArticleWithoutSubmit()
        {
            LoginPage loginuser = new LoginPage(this.driver);
            //loginuser.LoginUser("londa101@abv.bg", "londa101");
            loginuser.LoginUser("nikolova.petq@gmail.com", "P@ssw@rd");

            CreateArticle newArticle = new CreateArticle(this.driver);
            newArticle.ArticleNavigateTo();
            newArticle.AssertCancelButtonDisplayed();
            newArticle.ArticleCreateWithoutSubmit("Title CancelButton", "Content CancelButton");
           
            ArticlesDashboard dash = new ArticlesDashboard(this.driver);
            dash.AssertCancelArticle("Article Test Nury");
            loginuser.LogOffButton.Click();
        }

        [Test, Property("Priority", 1)] 
        [Author("Nury")]

        public void EditOwnArticleFromList()
        {
            LoginPage loginuser = new LoginPage(this.driver);
            //loginuser.LoginUser("londa101@abv.bg", "londa101");
            loginuser.LoginUser("nikolova.petq@gmail.com", "P@ssw@rd");

            CreateArticle newArticle = new CreateArticle(this.driver);
            newArticle.ArticleNavigateTo();
            newArticle.ArticleCreate("Article Test THREE", "Content Nury Test");

            ArticlesDashboard dash = new ArticlesDashboard(this.driver);
            EditArticle newEditArticle = new EditArticle(this.driver);
            newEditArticle.FindArticleByTitle("Article Test THREE");           
            newEditArticle.ArticleEdit("Article Test Nury3", "This is the text of article Nury3");
            dash.AssertFindArticleDashboard("Article Test Nury3");
            loginuser.LogOffButton.Click();
        }
        
        [Test, Property("Priority", 1)] 
        [Author("Nury")]

        public void EditArticleFromListWithoutLogin()
        {
            LoginPage loginuser = new LoginPage(this.driver);
           // loginuser.LoginUser("londa101@abv.bg", "londa101");
            loginuser.LoginUser("nikolova.petq@gmail.com", "P@ssw@rd");

            CreateArticle newArticle = new CreateArticle(this.driver);
            newArticle.ArticleNavigateTo();
            newArticle.ArticleCreate("Edited Article Test THREE", "Content Nury Test");
            ArticlesDashboard dash = new ArticlesDashboard(this.driver);
            dash.LogOut.Click();

            EditArticle newEditArticle = new EditArticle(this.driver);
            newEditArticle.FindArticleByTitle("Edited Article Test THREE");
            newEditArticle.AssertEditButtonDisplayed();
            newEditArticle.ArticleEditButton();
            
            loginuser.AssertAccountLogin();            
        }
        
        [Test, Property("Priority", 1)] 
        [Author("Nury")]
        [Category("SmokeTests")]

        public void DeleteOwnArticleFromList()
        {    
            LoginPage loginuser = new LoginPage(this.driver);
            //loginuser.LoginUser("londa101@abv.bg", "londa101");
            loginuser.LoginUser("nikolova.petq@gmail.com", "P@ssw@rd");

            CreateArticle newArticle = new CreateArticle(this.driver);
            newArticle.ArticleNavigateTo();
            newArticle.ArticleCreate("Own Deleted Article Test THREE", "Content Nury Test");
           
          
            DeleteArticle newDeleteArticle = new DeleteArticle(this.driver);          
            newDeleteArticle.ArticleDeletefromList("Own Deleted Article Test THREE");
            ArticlesDashboard dash = new ArticlesDashboard(this.driver);
            
            dash.AssertDeleteArticleDisplayed("Own Deleted Article Test THREE");
            dash.LogOut.Click();
        }

        [Test, Property("Priority", 1)] 
        [Author("Nury")]

        public void DeleteArticleFromListWithoutLogin()
        {
            LoginPage loginuser = new LoginPage(this.driver);
            //loginuser.LoginUser("londa101@abv.bg", "londa101");
            loginuser.LoginUser("nikolova.petq@gmail.com", "P@ssw@rd");

            CreateArticle newArticle = new CreateArticle(this.driver);
            newArticle.ArticleNavigateTo();
            newArticle.ArticleCreate("Deleted Article Test THREE", "Content Nury Test");
            ArticlesDashboard dash = new ArticlesDashboard(this.driver);
            dash.LogOut.Click();

            DeleteArticle newDeleteArticle = new DeleteArticle(this.driver);
            newDeleteArticle.ArticleDeleteButton("Deleted Article Test THREE"); 
            loginuser.AssertAccountLogin();            
        }
		
		[Test]
        [Author("Daniela Stefanova")]
		[TestOf("Login")]

        public void SuccessfulLoginTest()
        {
            var logPage = new LoginPage(this.driver);
            logPage.LoginNavigateTo();
            
           // LoginUser logUser = new LoginUser("daniela_popovo@abv.bg", "123456");
            LoginUser logUser = new LoginUser("nikolova.petq@gmail.com", "P@ssw@rd");
            logPage.FillLoginForm(logUser);
            logPage.SuccessfulLogin("Hello nikolova.petq@gmail.com!");
            logPage.LogOffButton.Click();
        }

        [Test]
        [Author("Daniela Stefanova")]
		[TestOf("Login")]

        public void LoginWithoutEmail()
        {
            var logPage = new LoginPage(this.driver);
            logPage.LoginNavigateTo();
            
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
            logPage.LoginNavigateTo();
           
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
            logPage.LoginNavigateTo();
          
            LoginUser logUser = new LoginUser("", "");
            logPage.FillLoginForm(logUser);

            logPage.AssertLoginFormEmailError("The Email field is required.");
            logPage.AssertLoginFormPasswordError("The Password field is required.");
        }

        [Test]
        [Author("Daniela Stefanova")]
		[TestOf("Login")]
        [Category("SmokeTests")]

        public void LoginWithInvalidPassword()
        {
            var logPage = new LoginPage(this.driver);
            logPage.LoginNavigateTo();
            
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
            logPage.LoginNavigateTo();
           
            LoginUser logUser = new LoginUser("daniela.daniela@google.tc", "123456");
            logPage.FillLoginForm(logUser);

            logPage.AssertInvalidEmailError("Invalid login attempt.");
        }
    }
}
