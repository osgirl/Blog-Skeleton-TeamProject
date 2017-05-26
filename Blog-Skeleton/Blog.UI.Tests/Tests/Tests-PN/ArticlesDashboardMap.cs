using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests.Tests.Tests_PN
{
    public partial class ArticlesDashboard
    {
        public IWebElement Article1Title
        {
            get
            {
                return this.Wait.Until(w => w.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/article/header/h2/a")));
            }
        }
         
            public IWebElement Article1Description
            {
                get
                 {
                    return this.Wait.Until(w => w.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/article/p/text()")));
                 }
         }

    }
}
