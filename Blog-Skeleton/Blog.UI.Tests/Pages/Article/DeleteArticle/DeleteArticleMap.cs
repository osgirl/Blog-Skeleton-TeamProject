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
                return this.Driver.FindElement(By.CssSelector("body > div.container.body-content > div > article > footer > a.btn.btn-danger.btn-xs"));
            }
        }

        public IWebElement BackButton
        {
            get
            {
                return this.Driver.FindElement(By.CssSelector("body > div.container.body-content > div > article > footer > a.btn.btn-default.btn-xs"));

            }
        }

        public IWebElement DeleteInsiteButton
        {
            get
            {
                return this.Driver.FindElement(By.CssSelector("body > div.container.body-content > div > div > form > div:nth-child(4) > div > input"));
            }
        }

        public IWebElement ContainerDashboard
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("body > div.container.body-content > div")));
            }
        }

        public IWebElement TitleLinkText
        {
            get
            {
                //return this.Wait.Until(w => w.FindElement(By.LinkText("Article Test THREE")));
                return this.Driver.FindElement(By.PartialLinkText("Article Test"));
            }
        }

     


    }
}
