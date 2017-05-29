using OpenQA.Selenium;

namespace Blog.UI.Tests.Pages.ArticlesDashboard
{
    public partial class ArticlesDashboard
    {
        public IWebElement Title3
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("body > div.container.body-content > div > div > div:nth-child(3) > article > header > h2 > a")));
            }
        }

        public IWebElement Content3
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("body > div.container.body-content > div > div > div:nth-child(3) > article > p")));
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

        public IWebElement ContainerDashboard
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("body > div.container.body-content > div")));
            }
        }
    }
}
