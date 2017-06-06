using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests.Pages.LoginPage
{
    public static class LoginPageAsserter
    {
        public static void AssertLogo(this LoginPage page)
        {
            //Assert.AreEqual("SOFTUNI BLOG", page.Logo.Text);
        }

        public static void AssertLoginFormEmailError(this LoginPage page, string text)
        {

            Assert.AreEqual(text, page.EmailError.Text);
        }

        public static void AssertLoginFormPasswordError(this LoginPage page, string text)
        {

            Assert.AreEqual(text, page.PasswordError.Text);

        }

        public static void AssertInvalidPasswordError(this LoginPage page, string text)
        {

            Assert.AreEqual(text, page.InvalidPassword.Text);

        }

        public static void AssertInvalidEmailError(this LoginPage page, string text)
        {
            Assert.AreEqual(text, page.InvalidEmail.Text);
        }

        public static void SuccessfulLogin(this LoginPage page, string text)
        {
            Assert.AreEqual(text, page.LogOffButton.Text);
        }

        public static void AssertPageUrl(this LoginPage loginUser)
        {
            Assert.AreEqual("http://localhost:60639/Article/Login", loginUser.URL);
        }

        public static void AssertLoginUser(this LoginPage loginUser)
        {
            Assert.AreEqual($"Hello {loginUser.EMAIL}!", loginUser.ManageUser.Text);
        }
    }
}
