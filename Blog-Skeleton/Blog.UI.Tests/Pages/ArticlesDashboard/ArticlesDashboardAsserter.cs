using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace Blog.UI.Tests.Pages.ArticlesDashboard
{
    public static class ArticleDashboardAsserter
    {
        public static void AssertPageUrl(this ArticlesDashboard dash)
        {
            Assert.AreEqual("http://localhost:60634/Article/List", dash.Url);
        }

        public static void AssertNewArticle(this ArticlesDashboard dash, string title)
        {            
            //int articlesCount= dash.ContainerDashboard.FindElements(By.CssSelector("body > div.container.body-content > div > div > div")).Count;
            IWebElement element = dash.ContainerDashboard.FindElement(By.XPath($".//a[text()='{title}']"));

           // for (int i=1;i< articlesCount;i++)
             //   Assert.AreEqual(title, element.Text);
            try
            {
                Assert.AreEqual(title, element.Text);
            }
            catch (Exception e)
            {
                dash.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Article is not found");
            }
        }        
    }
}
