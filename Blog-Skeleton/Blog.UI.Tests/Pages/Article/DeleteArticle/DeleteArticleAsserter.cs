using NUnit.Framework;

namespace Blog.UI.Tests.Pages.Article.DeleteArticle
{
    public static class DeleteArticleAsserter
    {
        public static void AssertDeleteButtonDisplayed(this DeleteArticle page)
        {
            Assert.IsTrue(page.DeleteButton.Displayed);
        }

        public static void AssertDeleteInsiteButtonDisplayed(this DeleteArticle page)
        {
            Assert.IsTrue(page.DeleteInsiteButton.Displayed);
        }        
    }
}
    
