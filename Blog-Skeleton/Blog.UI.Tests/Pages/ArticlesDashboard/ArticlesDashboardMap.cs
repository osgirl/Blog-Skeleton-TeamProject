using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Blog.UI.Tests.Pages.ArticlesDashboard
{
    public partial class ArticlesDashboard
    {
        public List<IWebElement> ContainerDashboard
        {
            get
            {
                var reminder = this.Wait.Until(w => w.FindElement(By.CssSelector("body > div.container.body-content > div")));
                List<IWebElement> list = reminder.FindElements(By.TagName("a")).ToList();
                return list;

            }
        }

        public IWebElement CreateButton
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("#logoutForm > ul > li:nth-child(1) > a")));
            }
        }

        public IWebElement LogOut
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("#logoutForm > ul > li:nth-child(3) > a")));
            }
        }

        public IWebElement ManageUser
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("# logoutForm > ul > li:nth-child(2) > a")));
            }
        }        
    }
}
