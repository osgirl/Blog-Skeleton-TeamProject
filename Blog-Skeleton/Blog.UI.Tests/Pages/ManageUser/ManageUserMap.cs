using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests.Pages.ManageUser
{
    public partial class ManageUser
    {

        public IWebElement OldPassword
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("#OldPassword")));
            }
        }

        public IWebElement NewPassword
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("#NewPassword")));
            }
        }
        
        public IWebElement ConfirmPassword
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("#ConfirmPassword")));
            }
        }

        public IWebElement ChangePasswordButton
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("body > div.container.body-content > div > div > form > div:nth-child(6) > div > input")));
            }
        }

        public IWebElement ChangePasswordLink
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("body > div.container.body-content > div > dl > dd > a")));
            }
        }
        
        public IWebElement SuccessfulMessageChangePassword
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("body > div.container.body-content > p")));
            }
        }
    }
}
