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
            try
            {
                Assert.AreEqual("http://localhost:60639/Article/List", dash.Url);
            }            
             catch (Exception e)
            {
                dash.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Article is not found");
            }
        }

        public static void AssertAvailableCreateButton(this ArticlesDashboard dash)
        {
            try
            {
                Assert.IsTrue(dash.CreateButton.Displayed);
                Assert.IsTrue(dash.CreateButton.Enabled);                
            }
            catch (Exception e)
            {
                dash.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Create button is missing");
            }
        }

        public static void AssertAvailableManageUserButton(this ArticlesDashboard dash)
        {
            try
            {                
                Assert.IsTrue(dash.ManageUser.Displayed);
                Assert.IsTrue(dash.ManageUser.Enabled);                
            }
            catch (Exception e)
            {
                dash.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"ManageUser button is missing");
            }
        }

        public static void AssertAuthorSign(this ArticlesDashboard dash)
        {
            try
            {    
                IWebElement foundArticle = dash.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[" + (dash.AuthorSign.Count - 1) + "]/article/footer/small"));
                Assert.AreEqual("--author", foundArticle.Text);
            }
            catch (Exception e)
            {
                dash.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Author Sign is missing");
            }
        }

        public static void AssertAvailableLogOutButton(this ArticlesDashboard dash)
        {
            try
            {                
                Assert.IsTrue(dash.LogOut.Displayed);
                Assert.IsTrue(dash.LogOut.Enabled);
            }
            catch (Exception e)
            {
                dash.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"LogOut button is missing");
            }
        }

        public static void AssertNewArticle(this ArticlesDashboard dash, string title)
        {
            try
            {
                IWebElement foundArticle = dash.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[" + (dash.ContainerDashboard.Count - 1) + "]/article/header/h2/a"));
                
                Assert.AreEqual(title, foundArticle.Text);
            }
            catch (Exception e)
            {
                dash.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Article is not found");
            }
        }

        public static void AssertCancelArticle(this ArticlesDashboard dash, string title)
        {
            try
            {
                IWebElement foundArticle = dash.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[" + (dash.ContainerDashboard.Count - 1) + "]/article/header/h2/a"));
              
                Assert.AreNotEqual(title, foundArticle.Text);

            }
            catch (Exception e)
            {
                dash.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Article is found");
            }
        }             
    }
}
