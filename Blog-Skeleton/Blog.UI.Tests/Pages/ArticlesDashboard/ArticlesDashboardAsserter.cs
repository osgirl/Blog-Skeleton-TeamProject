using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Windows.Forms;

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
            IWebElement element;
            
            try
            {
                element = dash.Wait.Until(w => dash.ContainerDashboard.FindElement(By.XPath($".//a[text()='{title}']")));
                Assert.AreEqual(title, element.Text);
            }
            catch (Exception e)
            {
                dash.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Article is not found");
            }
        }

        public static ScrollBars GetVisibleScrollbars(this ArticlesDashboard dash, ScrollableControl ctl)
        {
            if (ctl.HorizontalScroll.Visible)
                return ctl.VerticalScroll.Visible ? ScrollBars.Both : ScrollBars.Horizontal;
            else
                return ctl.VerticalScroll.Visible ? ScrollBars.Vertical : ScrollBars.None;
        }        
    }
}
