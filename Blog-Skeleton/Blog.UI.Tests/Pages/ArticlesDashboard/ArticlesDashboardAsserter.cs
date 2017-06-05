using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Web;
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

        public static void AssertAuthorSign(this ArticlesDashboard dash, string author)
        {
            try
            {
                IWebElement foundArticle = dash.AuthorSign[dash.AuthorSign.Count - 1];
                Assert.AreEqual(author, foundArticle.Text);
            }
            catch (Exception e)
            {
                dash.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Author Sign is missing");
            }
        }

        public static void AssertArticleDetails(this ArticlesDashboard dash, int ArticleId, string title, string content, string author)
        {
            try
            {
                string a = $"http://localhost:60639/Article/Details/{ArticleId}";
                Assert.AreEqual($"http://localhost:60639/Article/Details/{ArticleId}", dash.Driver.Url);
                Assert.AreEqual(dash.Title.Text, title);
                Assert.AreEqual(dash.Content.Text, content);
                Assert.AreEqual(dash.Author.Text, author);

                Assert.IsTrue(dash.EditButton.Displayed);
                Assert.IsTrue(dash.EditButton.Enabled);
                Assert.IsTrue(dash.DeleteButton.Displayed);
                Assert.IsTrue(dash.DeleteButton.Enabled);
                Assert.IsTrue(dash.BackButton.Displayed);
                Assert.IsTrue(dash.BackButton.Enabled);
            }
            catch (Exception e)
            {
                dash.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Some Articles details are missing");
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
                IWebElement foundArticle = dash.ContainerDashboard[dash.ContainerDashboard.Count - 1];
              
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
                IWebElement foundArticle = dash.ContainerDashboard[dash.ContainerDashboard.Count - 1];

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
