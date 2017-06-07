using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Blog.UI.Tests.Pages.Article.DeleteArticle
{
    public partial class DeleteArticle : BasePage
    {        
        private string title;
        
        public DeleteArticle(IWebDriver driver) : base(driver)
        {
        }
              
        public string TITLE
        {
            get
            {
                return this.title;
            }
        }

        public void ArticleDeletefromList(string title)
        {
            this.title = title;                      
            this.FindArticleByTitle(title);
            this.AssertDeleteButtonDisplayed();
            this.DeleteButton.Click();
            this.AssertDeleteInsiteButtonDisplayed();
            this.DeleteInsiteButton.Click();
        }

        public void ArticleDeleteButton(string title)
        {
            this.title = title;
            this.FindArticleByTitle(title);
            this.AssertDeleteButtonDisplayed();
            this.DeleteButton.Click();

        }

        public void FindArticleByTitle(string title)
        {
            var reminder = Wait.Until(w => w.FindElement(By.CssSelector("body > div.container.body-content > div > div")));
            List<IWebElement> list = reminder.FindElements(By.TagName("a")).ToList();
            IWebElement foundArticle = null;
            for (int i = 0; i < list.Count; i++)
                if (list[i].Text.Equals(title))
                    foundArticle = list[i];
            if (foundArticle == null)
                Assert.Fail("Not found Article in Dashboard");
            else
                foundArticle.Click();
        }
    }
}
