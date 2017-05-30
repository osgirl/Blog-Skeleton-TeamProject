using OpenQA.Selenium;
using System;

namespace Blog.UI.Tests.Pages.Login
{
    public partial class Login: BasePage
    {
        private string url = @"http://localhost:60634/Account/Login";
        private string email;
        private string password;

        public Login(IWebDriver driver): base(driver)
        {                 
        }

        public string EMAIL
        {
            get
            {
                return this.email;
            }

            set
            {
                this.email=value;
            }
        }

        public string PASSWORD
        {
            get
            {
                return this.password;
            }

            set
            {
                this.password = value;
            }
        }

        public string URL
        {
            get
            {
                return this.url;
            }
        }

        public void LoginNavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        public void LoginUser(string loginEmail, string loginPassword)
        {
            this.EMAIL = loginEmail;
            this.PASSWORD = loginPassword;
            this.LoginNavigateTo();
            this.Email.Click();
            this.Email.SendKeys(this.EMAIL);
            this.Password.Click();
            this.Password.SendKeys(this.PASSWORD);
            this.Remember.Click();
            this.LoginButton.Click();            
            this.AssertLoginUser();
        }
    }
}
