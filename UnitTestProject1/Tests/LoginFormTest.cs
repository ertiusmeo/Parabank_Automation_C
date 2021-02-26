using DarekTest.Pages;
using DarekTest.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace DarekTest.Tests
{
    [TestClass]
    public class LoginFormTest : BaseTest
    {
        [TestMethod]
        public void Login_SuccessfulAccess()
        {
            new LoginPage(Driver)
                .Go()
                .EnterCredentials("abc", "abc")
                .Submit();

            Assert.IsTrue(new WelcomePage(Driver).VerifyWelcomeMessageDisplayed(), "Welcome message is not displayed");

        }

        [TestMethod]
        public void Login_UnsuccessfulAccess()
        {
            var test = new LoginPage(Driver)
                 .Go()
                 .Submit();
            Assert.IsTrue(test.VerifyErrorMessageDisplayed(), "Error message is not displayed");
        }
    }
}