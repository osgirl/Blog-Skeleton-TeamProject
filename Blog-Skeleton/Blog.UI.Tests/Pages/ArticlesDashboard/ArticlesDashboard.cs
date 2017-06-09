using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Blog.UI.Tests.Pages.ArticlesDashboard
{
    public partial class ArticlesDashboard: BasePage
    {
        public ArticlesDashboard(IWebDriver driver): base(driver)
        {
        }
        
        public void ViewArticleByTitle(string title)
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

        public IWebElement FindArticleIdByTitle(string title)
        {
            var reminder = Wait.Until(w => w.FindElement(By.CssSelector("body > div.container.body-content > div > div")));
            List<IWebElement> list = reminder.FindElements(By.TagName("a")).ToList();
            IWebElement element = null;
            for (int i = 0; i < list.Count; i++)
                if (list[i].Text.Equals(title))
                    element = list[i];
            Assert.IsTrue(element != null, "Article is displayed in Dashboard", "Not found Article in Dashboard");
            return element;
        }
    }
}
