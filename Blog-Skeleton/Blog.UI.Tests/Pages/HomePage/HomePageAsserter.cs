using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests.Pages.HomePage
{
    public static class HomePageAsserter
    {
        public static void AssertLogo(this HomePage page)
        {
            Assert.AreEqual("SOFTUNI BLOG", page.Logo.Text);
        }
    }
}
