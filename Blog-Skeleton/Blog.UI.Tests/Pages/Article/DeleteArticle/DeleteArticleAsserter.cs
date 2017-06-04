using NUnit.Framework;

namespace Blog.UI.Tests.Pages.Article.DeleteArticle
{
    public static class DeleteArticleAsserter
    {

        public static void AssertDeleteButtonDesplayed(this DeleteArticle page)
        {
            Assert.IsTrue(page.DeleteButton.Displayed);
        }

        public static void AssertDeleteInsiteButtonDesplayed(this DeleteArticle page)
        {
            Assert.IsTrue(page.DeleteInsiteButton.Displayed);
        }

    }
}
    
