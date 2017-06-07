using NUnit.Framework;

namespace Blog.UI.Tests.Pages.Article.EditArticle
{
    public static class EditArticleAsserter
    {
        public static void AssertEditButtonDisplayed(this EditArticle page)
        {
            Assert.IsTrue(page.EditButton.Displayed);
        }
    }
}
