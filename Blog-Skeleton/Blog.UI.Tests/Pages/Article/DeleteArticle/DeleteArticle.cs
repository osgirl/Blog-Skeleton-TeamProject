using OpenQA.Selenium;


namespace Blog.UI.Tests.Pages.Article.DeleteArticle
{
    public partial class DeleteArticle : BasePage
    {
        private string url = @"http://localhost:60639/Article/List";
        private string title = "Article Test THREE";
        
        public DeleteArticle(IWebDriver driver) : base(driver)
        {
        }
              
        public string TITLE
        {
            get
            {
                return this.title;
            }
        }
        public void ArticleDeletefromList(string title)
        {          
            this.TitleLinkText.Click();
            this.DeleteButton.Click();
            this.DeleteInsiteButton.Click();
        }

        public void ArticleDeleteButton()
        {
            this.TitleLinkText.Click();
            this.DeleteButton.Click();
            
        }
    }
}
