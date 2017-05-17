using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.Seleno.Configuration;

namespace Blog.UI.Tests
{
    public static class BrowserHost
    {
        public static readonly SelenoHost Instance = new SelenoHost();
        public static readonly string RootUrl = @"http://localhost:60634/Article/List";

        static BrowserHost()
        {
            //Use different port for instance from localhost, because there is a discrepancy using TeamCity

           // Instance.Run("Blog", 60634, w => w.WithRemoteWebDriver(BrowserFactory.Chrome));
             Instance.Run("Blog", 60639, w => w.WithRemoteWebDriver(() => new ChromeDriver()));
            
           // Instance.Run("Blog", 60634);
            // For Chrome: Instance.Run("Blog", 60634, w => w.WithRemoteWebDriver(BrowserFactory.Chrome));
            // or Instance.Run("Blog", 60634, w => w.WithRemoteWebDriver(() => new ChromeDriver()));

            RootUrl = Instance.Application.Browser.Url;
        }
    }
}
