using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.UI.Tests.Models;

namespace Blog.UI.Tests.Pages.LoginPage
{
    public partial class LoginPage : BasePage
    {
        private string urL = @"http://localhost:60639/Account/Login";
        private string email;
        private string password;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            //AccessExcelData.fileName = "LogInData.xlsx";
        }

        public string EMAIL
        {
            get
            {
                return this.email;
            }

            set
            {
                this.email = value;
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
                return this.urL;
            }
        }

        /*
        public new void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl("http://localhost:60639/Article/List");
            LoginButton.Click();
        }
        */

        public void LoginNavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        public void LoginUser(string loginEmail, string loginPassword)
        {
            this.EMAIL = loginEmail;
            this.PASSWORD = loginPassword;
            this.LoginNavigateTo();
            this.EmailField.Click();
            this.EmailField.SendKeys(this.EMAIL);
            this.PasswordField.Click();
            this.PasswordField.SendKeys(this.PASSWORD);
            this.RememberMeCheckbox.Click();            
            this.LogInSubmit.Click();
            this.AssertLoginUser();            
        }

        public void LoginButtonClick()
        {
            this.Driver.FindElement(By.Id("loginLink")).Click();
        }

        public void FillLoginForm(LoginUser loginUser)
        {
            Type(EmailField, loginUser.Email);
            Type(PasswordField, loginUser.Password);

            LogInSubmit.Click();
        }
        
        public void RememberMeClick()
        {
            this.Driver.FindElement(By.Id("RememberMe")).Click();
        }

        private void Type(IWebElement element, string text)
        {
            element.Click();

            if (!text.Equals("Field-Empty"))
            {
                element.SendKeys(text);

            }
        }
    }
}
