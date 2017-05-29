using OpenQA.Selenium;

namespace Blog.UI.Tests.Pages.Login
{
    public partial class Login : BasePage
    {
        public IWebElement Email
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("#Email")));
            }
        }

        public IWebElement Password
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("#Password")));
            }
        }
        
        public IWebElement LoginButton
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("body > div.container.body-content > div > div > form > div:nth-child(5) > div > input")));
            }
        }

        public IWebElement Remember
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("#RememberMe")));
            }
        }

        public IWebElement ManageUser
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li[2]/a")));
            }
        }

    }
}
