using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Blog.UI.Tests.Pages.ArticlesDashboard
{
    public static class ArticleDashboardAsserter
    {
        public static void AssertPageUrl(this ArticlesDashboard dash)
        {
            Assert.AreEqual("http://localhost:60638/Article/List", dash.Url);
        }

        public static void AssertNewArticle(this ArticlesDashboard dash, string title)
        {   
            try
            {/*
                List<IWebElement> foundArticle = new List<IWebElement>();

                for (int i = 0; i < dash.ContainerDashboard.Count; i++)                    
                    {
                        if (dash.ContainerDashboard[i].Text.Equals(title))
                            foundArticle[i] = dash.ContainerDashboard[i];
                    }
                    */
                Assert.AreEqual(title, dash.ContainerDashboard[dash.ContainerDashboard.Count-1].Text);                
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
                Assert.AreNotEqual(title, dash.ContainerDashboard[dash.ContainerDashboard.Count - 1].Text);
            }
            catch (Exception e)
            {
                dash.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Article is found");
            }
        }

        public static ScrollBars GetVisibleScrollbars(this ArticlesDashboard dash, ScrollableControl ctl)
        {
            if (ctl.HorizontalScroll.Visible)
                return ctl.VerticalScroll.Visible ? ScrollBars.Both : ScrollBars.Horizontal;
            else
                return ctl.VerticalScroll.Visible ? ScrollBars.Vertical : ScrollBars.None;
        }
        /*
        public static void AssertAuthorSign(this ArticlesDashboard dash, ScrollableControl ctl)
        {
            if (ctl.HorizontalScroll.Visible)
                 ctl.VerticalScroll.Visible ? ScrollBars.Both : ScrollBars.Horizontal;
            else
                 ctl.VerticalScroll.Visible ? ScrollBars.Vertical : ScrollBars.None;
        }*/
    }
}
