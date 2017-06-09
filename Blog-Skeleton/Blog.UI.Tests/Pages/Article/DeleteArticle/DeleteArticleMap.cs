using NUnit.Framework;
using OpenQA.Selenium;

namespace Blog.UI.Tests.Pages.Article.DeleteArticle
{
    public partial class DeleteArticle : BasePage
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
        
        public IWebElement DeleteButton
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.XPath("/html/body/div[2]/div/article/footer/a[2]")));
            }
        }

        public IWebElement BackButton
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("body > div.container.body-content > div > article > footer > a.btn.btn-default.btn-xs")));

            }
        }

        public IWebElement DeleteInsiteButton
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[3]/div/input")));
            }
        }      
    }
}
