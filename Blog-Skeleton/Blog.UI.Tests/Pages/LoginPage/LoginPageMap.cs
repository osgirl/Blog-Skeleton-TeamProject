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
        public IWebElement LoginButton
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.Id("loginLink")));
            }
        }

        public IWebElement RememberMeCheckbox
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.Id("RememberMe")));
            }
        }

        public IWebElement EmailField
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("#Email")));
            }
        }

        public IWebElement PasswordField
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("#Password")));
            }
        }

        public IWebElement LogInSubmit
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/input"));
            }
        }
        public IWebElement EmailError
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/div/span/span"));
            }
        }
        public IWebElement PasswordError
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[2]/div/span/span"));
            }
        }

        public IWebElement InvalidError
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li"));
            }
        }
       
        public IWebElement LogOffButton
        {
            get
            {
                return this.Driver.FindElement(By.CssSelector("#logoutForm > ul > li:nth-child(3) > a"));
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
