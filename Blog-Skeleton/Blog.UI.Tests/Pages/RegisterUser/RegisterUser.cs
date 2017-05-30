using OpenQA.Selenium;

namespace Blog.UI.Tests.Pages.RegisterUser
{
    public partial class RegisterUser: BasePage
    {
        private string url = @"http://localhost:60634/Account/Register";

        public RegisterUser(IWebDriver driver): base(driver)
        {            
        }

        public string URL
        {
            get
            {
                return this.url;
            }
        }

        public void RegisterUserNavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        public void RegisterationOfUser(string email, string fullName,string password)
        {
            this.RegisterUserNavigateTo();
            this.Email.Click();
            this.Email.SendKeys(email);
            this.FullName.Click();
            this.FullName.SendKeys(fullName);
            this.Password.Click();
            this.Password.SendKeys(password);
            this.ConfirmPassword.Click();
            this.ConfirmPassword.SendKeys(password);
            this.RegisterButton.Click();
        }
    }
}
