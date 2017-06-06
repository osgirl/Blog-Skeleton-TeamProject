using OpenQA.Selenium;

namespace Blog.UI.Tests.Pages.RegisterUser
{
    public partial class RegisterUser
    {
        public IWebElement Email
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("#Email")));
            }
        }

        public IWebElement FullName
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("#FullName")));
            }
        }

        public IWebElement Password
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("#Password")));
            }
        }
        
        public IWebElement ConfirmPassword
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("#ConfirmPassword")));
            }
        }

        public IWebElement RegisterButton
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("body > div.container.body-content > div > div > form > div:nth-child(7) > div > input")));
            }
        }

        public IWebElement ManageUser
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("#logoutForm > ul > li:nth-child(2) > a")));
            }
        }
    }
}
