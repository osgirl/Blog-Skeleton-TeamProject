using OpenQA.Selenium;

namespace Blog.UI.Tests.Pages.CreateArticle
{
    public partial class CreateArticle: BasePage
    {
        private string url = @"http://localhost:60634/Article/Create";

        public CreateArticle(IWebDriver driver): base(driver)
        {            
        }

        public string URL
        {
            get
            {
                return this.url;
            }
        }

        public void ArticleNavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        public void ArticleCreate(string title, string content)
        {
            this.ArticleNavigateTo();
            this.Title.Click();
            this.Title.SendKeys(title);
            this.Content.Click();
            this.Content.SendKeys(content);
            this.CreateButton.Click();
        }
    }
}
