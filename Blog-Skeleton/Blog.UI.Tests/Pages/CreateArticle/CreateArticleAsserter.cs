﻿using NUnit.Framework;

namespace Blog.UI.Tests.Pages.CreateArticle
{
    public static class CreateArticleAsserter
    {
        public static void AssertPageUrl(this CreateArticle newArticle)
        {
            Assert.AreEqual("http://localhost:60639/Article/List", newArticle.URL);
        }      
    }
}
