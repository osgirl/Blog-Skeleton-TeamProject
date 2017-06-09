using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests.Pages.ManageUser
{
    public partial class ManageUser : BasePage
    {
        private string password;
        private string url = "http://localhost:60639/Manage";

        public ManageUser(IWebDriver driver): base(driver)
        {
        }

        public string PasswordUser
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
        
        public string UrlUser
        {
            get
            {
                return this.url;
            }
        }

        public void ManageNavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.UrlUser);
        }
        
        public void FillChangePasswordForm(string password)
        {
            Type(OldPassword, this.PasswordUser);
            Type(NewPassword, password);
            Type(ConfirmPassword, password);

            ChangePasswordButton.Click();
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
