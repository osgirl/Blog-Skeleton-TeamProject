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
                return this.Driver.FindElement(By.CssSelector("body > div.container.body-content > div > article > footer > a.btn.btn-success.btn-xs"));
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
                return this.Driver.FindElement(By.CssSelector("body > div.container.body-content > div > div > form > div:nth-child(7) > div > input"));
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

        public IWebElement TitleLinkText
        {
            get
            {
                return this.Driver.FindElement(By.PartialLinkText("Article Test"));
            }
        }
        
    }
}
    

