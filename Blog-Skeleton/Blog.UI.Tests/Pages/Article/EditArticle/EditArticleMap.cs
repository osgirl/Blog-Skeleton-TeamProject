using NUnit.Framework;
using OpenQA.Selenium;

namespace Blog.UI.Tests.Pages.Article.EditArticle

{
    public partial class EditArticle : BasePage
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

        public IWebElement EditButton
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.XPath("/html/body/div[2]/div/article/footer/a[1]")));
            }
        }
       
        public IWebElement DeleteButton
        {
            get
            {
                return this.Driver.FindElement(By.CssSelector("/body > div.container.body-content > div > article > footer > a.btn.btn-danger.btn-xs"));
            }
        }
    
        public IWebElement BackButton
        {
            get
            {
                return this.Driver.FindElement(By.CssSelector("body > div.container.body-content > div > article > footer > a.btn.btn-default.btn-xs"));

            }
        }

        public IWebElement EditInsideButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/input"));
            }
        }

        public IWebElement DeleteInsiteButton
        {
            get
            {
                return this.Driver.FindElement(By.CssSelector("body > div.container.body-content > div > div > form > div:nth-child(4) > div > input"));
            }
        }
        

        public IWebElement CancelButton
        {
            get
            {
                return this.Driver.FindElement(By.CssSelector("body > div.container.body-content > div > div > form > div:nth-child(7) > div > a"));
            }
        }
    }
}
    

