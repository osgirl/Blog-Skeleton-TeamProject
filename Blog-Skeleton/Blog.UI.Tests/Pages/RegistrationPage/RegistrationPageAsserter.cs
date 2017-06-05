using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests.Pages.RegistrationPage
{
    public static class RegistrationPageAsserter
    {

        public static void AssertRegistrationFormError(this RegistrationPage page, string text)
        {
            Assert.AreEqual(text, page.RegistrationFormError.Text);
            //      
        }
        public static void AssertRegistrationEmail(this RegistrationPage page, string text)
        {
            Assert.AreEqual(text, page.ErrorMessageEmailRequired.Text);

        }
        public static void AssertRegistrationFullName(this RegistrationPage page, string text)
        {
            Assert.AreEqual(text, page.ErrorMessageFullNameRequired.Text);

        }
        public static void AssertRegistrationPassword(this RegistrationPage page, string text)
        {
            Assert.AreEqual(text, page.RegistrationFormError.Text);

        }
        public static void AssertRegistrationErrorEmailFullNamePasswordRequired(this RegistrationPage page, string[] text)
        {
            List<string> actual = new List<string>() { page.ErrorMessageEmailRequired.Text, page.ErrorMessageFullNameRequired.Text, page.ErrorMessagePasswordRequired.Text };
            CollectionAssert.AreEqual(text, actual);
        }
    }
}
