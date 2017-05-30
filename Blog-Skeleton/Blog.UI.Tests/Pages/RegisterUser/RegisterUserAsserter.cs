using NUnit.Framework;

namespace Blog.UI.Tests.Pages.RegisterUser
{
    public static class RegisterUserAsserter
    {
        public static void AssertNewUser(this RegisterUser newUser, string email)
        {            
            Assert.AreEqual($"Hello {email}!", newUser.ManageUser.Text);
            Assert.AreEqual("http://localhost:60634/Article/List", newUser.URL);
        }     
    }
}
