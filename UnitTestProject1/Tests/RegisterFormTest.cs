
using DarekTest.Base;
using DarekTest.Pages;
using DarekTest.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DarekTest.Tests
{
    [TestClass]
    public class RegisterFormTest : BaseTest
    {
        

        [TestMethod]
        public void Register_OpenForm()
        {
            var test=new LoginPage(Driver)
                .Go()
                .Register();

            Assert.IsTrue(test.VerifyRegistrationFormDisplayed(), "Registration form is not displayed");

        }


        [TestMethod]
        public void Register_Successful()
        {
            var test = new LoginPage(Driver)
                .Go()
                .Register()
                .FillOutTheForm()
                .FillinTheField(RegistrationFields.Password, "abc")
                .FillinTheField(RegistrationFields.ConfirmPassword, "abc")
                .SubmitAndContinue();

           Assert.IsTrue(test.VerifySuccessMessageDisplayed(), "Succesful registration message is not displayed");

        }

        [DataRow(RegistrationFields.FirstName)]
        [DataRow(RegistrationFields.LastName)]
        [DataRow(RegistrationFields.Address)]
        [DataRow(RegistrationFields.City)]
        [DataRow(RegistrationFields.State)]
        [DataRow(RegistrationFields.ZipCode)]
        [DataRow(RegistrationFields.Username)]
        [DataRow(RegistrationFields.Password)]
        [DataRow(RegistrationFields.ConfirmPassword)]
        [DataTestMethod]
        public void Register_NoRequiredField(string field)
        {
            var test = new LoginPage(Driver)
                .Go()
                .Register()
                .FillOutTheFormExcept(field)
                .Submit();
               
           Assert.IsTrue(test.VerifyRequiredFieldMessageDisplayed(), $"Error message for field {field} is not displayed");

        }



        [TestMethod]
        public void Register_PasswordNotMatching()
        {
            var test = new LoginPage(Driver)
                .Go()
                .Register()
                .FillOutTheForm()
                .FillinTheField(RegistrationFields.Password, "abc")
                .FillinTheField(RegistrationFields.ConfirmPassword, "xyz")
                .Submit();

           Assert.IsTrue(test.VerifyPasswordNotMatchingErrorDisplayed(), "Password not matching error is not displayed");

        }

        [TestMethod]
        public void Register_UsernameExists()
        {

            string username = CommonFunctions.RandomString(5);

            new LoginPage(Driver)
                .Go()
                .Register()
                .FillOutTheForm()
                .FillinTheField(RegistrationFields.Username, username)
                .FillinTheField(RegistrationFields.Password, "abc")
                .FillinTheField(RegistrationFields.ConfirmPassword, "abc")
                .SubmitAndContinue()
                .Logout();

            var test= new LoginPage(Driver)
                .Go()
                .Register()
                .FillOutTheForm()
                .FillinTheField(RegistrationFields.Username, username)
                .FillinTheField(RegistrationFields.Password, "abc")
                .FillinTheField(RegistrationFields.ConfirmPassword, "abc")
                .Submit();

            Assert.IsTrue(test.VerifyUsernameExistsMessageDisplayed(), "Username exists error is not displayed");

        }


    }
}
