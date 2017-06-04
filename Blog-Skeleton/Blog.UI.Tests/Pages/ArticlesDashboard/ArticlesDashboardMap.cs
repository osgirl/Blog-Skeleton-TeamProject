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

        //nury
        public IWebElement ArticleAutor
        {
            get
            {
                //return this.Wait.Until(w => w.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/article/footer/small")));
                return this.Wait.Until(w => w.FindElement(By.CssSelector("body > div.container.body - content > div > div > div:nth - child(1) > article > footer > small")));
            }
        }

        public IWebElement CreateLink
        {
            get
            {
                //return this.Wait.Until(w => w.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li[1]/a")));
                return this.Wait.Until(w => w.FindElement(By.CssSelector("#logoutForm > ul > li:nth-child(1) > a")));

            }
        }
       
    }
}
