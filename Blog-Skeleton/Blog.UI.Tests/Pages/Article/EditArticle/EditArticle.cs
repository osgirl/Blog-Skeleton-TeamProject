using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Blog.UI.Tests.Pages.Article.EditArticle
{
    public partial class EditArticle : BasePage
    {     
        public EditArticle(IWebDriver driver) : base(driver)
        {
        }
               
        public void ArticleEdit(string title, string content)
        {
            this.EditButton.Click();
            this.Title.Click();
            this.Title.Clear();
            this.Title.SendKeys(title);
            this.Content.Click();
            this.Content.Clear();
            this.Content.SendKeys(content);
            this.EditInsideButton.Click();
        }
    
        public void ArticleEditButton()
        {            
            this.EditButton.Click();
           
        }            
    }
}
