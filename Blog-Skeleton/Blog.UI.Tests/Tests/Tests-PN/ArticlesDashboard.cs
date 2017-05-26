using Blog.UI.Tests.Pages.HomePage;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests.Tests.Tests_PN
{
    public partial class ArticlesDashboard: HomePage
    {
        public ArticlesDashboard(IWebDriver driver): base(driver)
        {
        }

        public void NavigateToArticle(string title)
        {
            for(int i;i<Count;i++)
                this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/div["+i+"]/article/header/h2/a"))

            this.Driver.Navigate().GoToUrl(this.url);
        }

        // No Articles

        // One Article

        // Three Articles (check, title, description, author)

        // Changed Article with different characters (title, description)

        // Article with long title

        // Article with long description (outside screen)

        // View Article

        // More Articles with activated scroll bar

        // Available buttons Edit, Delete, Back

    }
}
