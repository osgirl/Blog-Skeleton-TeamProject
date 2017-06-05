using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests.Pages.LoginPage
{
    public partial class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
            //AccessExcelData.fileName = "LogInData.xlsx";
        }


        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl("http://localhost:60634/Article/List");
            LoginButton.Click();
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
