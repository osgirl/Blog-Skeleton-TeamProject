using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Blog.UI.Tests.Pages.Article.EditArticle
{
    public partial class EditArticle : BasePage
    {     
        public EditArticle(IWebDriver driver) : base(driver)
        {
        }
               
        public void ArticleEdit(string title, string content)
        {
            this.EditButton.Click();
            this.Title.Click();
            this.Title.Clear();
            this.Title.SendKeys(title);
            this.Content.Click();
            this.Content.Clear();
            this.Content.SendKeys(content);
            this.EditInsideButton.Click();
        }
    
        public void ArticleEditButton()
        {            
            this.EditButton.Click();
           
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

        public int FindArticleIdByTitle(string title)
        {
            var reminder = Wait.Until(w => w.FindElement(By.CssSelector("body > div.container.body-content > div > div")));
            List<IWebElement> list = reminder.FindElements(By.TagName("a")).ToList();
            int a = new int();
            for (int i = 0; i < list.Count; i++)
                if (list[i].Text.Equals(title))
                    a= i;
            if (a.Equals(null))
                Assert.Fail("Not found Article in Dashboard");
            return a;
        }
    }
}
