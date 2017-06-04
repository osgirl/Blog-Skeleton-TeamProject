using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Blog.UI.Tests.Pages.Article.CreateArticle
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
        public IWebElement ErrorMessageTitle
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li[1]")));
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li[1]"));
            }
        }

        public IWebElement ErrorMessageTitleLength
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li")));
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li"));
            }
        }

        public IWebElement ErrorMessageContent
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li[2]")));
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li[2]"));
            }
        }
    }
}
