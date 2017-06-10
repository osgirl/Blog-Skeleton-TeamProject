using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.UI.Tests.Pages.ManageUser
{
    public static class ManageUserAsserter
    {
        public static void AssertManageUserPageURL(this ManageUser changePassword)
        {
            Assert.AreEqual("http://localhost:60639/Manage/ChangePassword", changePassword.Driver.Url);
        }

        public static void AssertManageUserURL(this ManageUser changePassword)
        {
            Assert.AreEqual("http://localhost:60639/Manage", changePassword.Driver.Url);
        }

        public static void AssertSuccessfulMessageChangePassword(this ManageUser changePassword)
        {
            Assert.AreEqual("Your password has been changed.", changePassword.SuccessfulMessageChangePassword.Text);
        }
    }
}
