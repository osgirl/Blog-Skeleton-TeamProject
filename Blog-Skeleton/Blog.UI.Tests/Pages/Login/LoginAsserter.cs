using NUnit.Framework;

namespace Blog.UI.Tests.Pages.Login
{
    public static class LoginAsserter
    {
        public static void AssertPageUrl(this Login loginUser)
        {
            Assert.AreEqual("http://localhost:60639/Article/Login%", loginUser.URL);
        }

        public static void AssertLoginUser(this Login loginUser)
        {            
            Assert.AreEqual($"Hello {loginUser.EMAIL}!", loginUser.ManageUser.Text);
        }
    }
}
