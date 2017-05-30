using OpenQA.Selenium;

namespace Blog.UI.Tests.Pages.CreateArticle
{
    public partial class CreateArticle
    {
        public IWebElement Title
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("#Title")));
            }
        }

        public IWebElement Content
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("#Content")));
            }
        }

        public IWebElement CreateButton
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("body > div.container.body-content > div > div > form > div:nth-child(5) > div > input")));
            }
        }

        public IWebElement CancelButton
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("body > div.container.body-content > div > div > form > div:nth-child(5) > div > a")));
            }
        }
    }
}
