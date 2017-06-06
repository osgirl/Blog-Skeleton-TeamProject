﻿using NUnit.Framework;
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

        public static void AssertFunctionalMenuButtons(this ArticlesDashboard dash)
        {
            try
            {
                dash.CreateButton.Click();
                Assert.AreEqual("http://localhost:60639/Article/Create", dash.Driver.Url);
                dash.Driver.Navigate().Back();
                dash.ManageUser.Click();
                Assert.AreEqual("http://localhost:60639/Manage", dash.Driver.Url);
                dash.Driver.Navigate().Back();
                dash.LogOut.Click();
                Assert.AreEqual("http://localhost:60639/Article/List", dash.Driver.Url);
                Assert.IsTrue(dash.Login.Displayed);
                Assert.IsTrue(dash.Login.Enabled);
            }
            catch (Exception e)
            {
                dash.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Create button is missing");
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

        public static void AssertArticleDetailsView(this ArticlesDashboard dash, int ArticleId, string title, string content, string author)
        {
            try
            {
               // Assert.AreEqual($"http://localhost:60639/Article/Details/{ArticleId}", dash.Driver.Url);
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


        public static void AssertArticleDetailsDashboard(this ArticlesDashboard dash, int ArticleId, string title, string content, string author)
        {
            try
            {
                IWebElement foundArticleTitle = dash.ContainerDashboardTitle[ArticleId - 1];
                IWebElement foundArticleContent = dash.ContainerDashboardContent[ArticleId - 1];
                IWebElement foundArticleAuthorSign = dash.AuthorSign[ArticleId - 1];
                Assert.AreEqual(title, foundArticleTitle.Text);
                Assert.AreEqual(content, foundArticleContent.Text);
                Assert.AreEqual(author, foundArticleAuthorSign.Text);
            }
            catch (Exception e)
            {
                dash.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Article is not found");
            }
        }

        public static void AssertNewArticle(this ArticlesDashboard dash, string title, string content)
        {
            try
            {
                IWebElement foundArticleTitle = dash.ContainerDashboardTitle[dash.ContainerDashboardTitle.Count - 1];
                IWebElement foundArticleContent = dash.ContainerDashboardContent[dash.ContainerDashboardContent.Count - 1];
                Assert.AreEqual(title, foundArticleTitle.Text);
                Assert.AreEqual(content, foundArticleContent.Text);
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
                IWebElement foundArticle = dash.ContainerDashboardTitle[dash.ContainerDashboardTitle.Count - 1];

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
