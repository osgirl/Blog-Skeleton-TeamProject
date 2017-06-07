using NUnit.Framework;

namespace Blog.UI.Tests.Pages.Article.CreateArticle
{
    public static class CreateArticleAsserter
    {
        public static void AssertPageUrl(this CreateArticle newArticle)
        {
            Assert.AreEqual("http://localhost:60639/Article/List", newArticle.URL);
        }

        public static void AssertTitleErrorMessage(this CreateArticle page, string text)
        { 
            Assert.IsTrue(page.ErrorMessageTitle.Displayed);
            StringAssert.Contains(text, page.ErrorMessageTitle.Text);
        }

        public static void AssertTitleLengthErrorMessage(this CreateArticle page, string text)
        {
            Assert.IsTrue(page.ErrorMessageTitle.Displayed);
            StringAssert.Contains(text, page.ErrorMessageTitle.Text);
        }

        public static void AssertContentErrorMessage(this CreateArticle page, string text)
        {
            Assert.IsTrue(page.ErrorMessageTitle.Displayed);
            StringAssert.Contains(text, page.ErrorMessageTitle.Text);
        }

        public static void AssertCancelButtonDisplayed(this CreateArticle page)
        {
            Assert.IsTrue(page.CancelButton.Displayed);
        }      
    }
}
