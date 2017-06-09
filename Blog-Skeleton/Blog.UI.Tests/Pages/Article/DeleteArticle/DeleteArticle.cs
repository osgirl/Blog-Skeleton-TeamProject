using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Blog.UI.Tests.Pages.Article.DeleteArticle
{
    public partial class DeleteArticle : BasePage
    {        
        private string title;
        
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
            this.title = title;                                  
            this.AssertDeleteButtonDisplayed();
            this.DeleteButton.Click();
            this.AssertDeleteInsiteButtonDisplayed();
            this.DeleteInsiteButton.Click();
        }

        public void ArticleDeleteButton(string title)
        {
            this.title = title;            
            this.AssertDeleteButtonDisplayed();
            this.DeleteButton.Click();

        }        
    }
}
