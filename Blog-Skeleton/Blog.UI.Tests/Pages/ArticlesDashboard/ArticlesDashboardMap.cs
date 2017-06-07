using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Blog.UI.Tests.Pages.ArticlesDashboard
{
    public partial class ArticlesDashboard
    {
        public IWebElement CreateButton
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("#logoutForm > ul > li:nth-child(1) > a")));
            }
        }
        
        public IWebElement Login
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("#loginLink")));
            }
        }

        public IWebElement LogOut
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.CssSelector("#logoutForm > ul > li:nth-child(3) > a")));
            }
        }

        public IWebElement ManageUser
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li[2]/a")));
            }
        }

        public List<IWebElement> ContainerDashboardTitle
        {
            get
            {
                var reminder = this.Wait.Until(w => w.FindElement(By.CssSelector("body > div.container.body-content > div > div")));
                
                List<IWebElement> list = reminder.FindElements(By.TagName("a")).ToList();
                return list;

            }
        }

        public List<IWebElement> ContainerDashboardContent
        {
            get
            {
                var reminder = this.Wait.Until(w => w.FindElement(By.CssSelector("body > div.container.body-content > div > div")));

                List<IWebElement> list = reminder.FindElements(By.TagName("p")).ToList();
                return list;

            }
        }

        public List<IWebElement> AuthorSign
        {
            get
            {
                var reminder = this.Wait.Until(w => w.FindElement(By.XPath("/html/body/div[2]/div/div")));
                List<IWebElement> list = reminder.FindElements(By.TagName("small")).ToList();
                return list;

            }
        }

        //nury
        public IWebElement ArticleAuthor
        {
            get
            {
                //return this.Wait.Until(w => w.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/article/footer/small")));
                return this.Wait.Until(w => w.FindElement(By.CssSelector("body > div.container.body - content > div > div > div:nth - child(1) > article > footer > small")));
            }
        } 
        
        public IWebElement EditButtonArticle
        {
            get
            {

                return this.Wait.Until(w => w.FindElement(By.XPath("/html/body/div[2]/div/article/footer/a[1]")));
            }
        }

        public IWebElement DeleteButtonArticle
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.XPath("/html/body/div[2]/div/article/footer/a[2]")));
            }
        }

        public IWebElement BackButtonArticle
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.XPath("/html/body/div[2]/div/article/footer/a[3]")));
            }
        }
        
        public IWebElement Title
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.XPath("/html/body/div[2]/div/article/header/h2")));
            }
        }

        public IWebElement Content
        { 
            get
            {
                return this.Wait.Until(w => w.FindElement(By.XPath("/html/body/div[2]/div/article/p")));
            }
        }

        public IWebElement Author
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.XPath("/html/body/div[2]/div/article/small")));
            }
        }
    }
}
