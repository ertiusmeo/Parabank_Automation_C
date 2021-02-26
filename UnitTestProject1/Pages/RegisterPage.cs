using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using DarekTest.Base;
using DarekTest.Providers;

namespace DarekTest.Pages
{
    public class RegisterPage : BasePage
    {

        public RegisterPage(IWebDriver driver) : base(driver)
        {
            errorList.Add(RegistrationFields.FirstName, RegistrationErrors.FirstName);
            errorList.Add(RegistrationFields.LastName, RegistrationErrors.LastName);
            errorList.Add(RegistrationFields.Address, RegistrationErrors.Address);
            errorList.Add(RegistrationFields.City, RegistrationErrors.City);
            errorList.Add(RegistrationFields.State, RegistrationErrors.State);
            errorList.Add(RegistrationFields.ZipCode, RegistrationErrors.ZipCode);
            errorList.Add(RegistrationFields.SSN, RegistrationErrors.SSN);
            errorList.Add(RegistrationFields.Username, RegistrationErrors.Username);
            errorList.Add(RegistrationFields.Password, RegistrationErrors.Password);
            errorList.Add(RegistrationFields.ConfirmPassword, RegistrationErrors.ConfirmPassword);
        }

        private Dictionary<string, string> errorList = new Dictionary<string, string>();
        private string emptyField;

        private IWebElement WelcomeMessage => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[contains(text(),'Signing up is easy!')]")));
        private IWebElement RegistrationForm => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//table[@class='form2']")));
        private IReadOnlyCollection<IWebElement> FieldsList => RegistrationForm.FindElements(By.XPath(".//input[@class='input']/../.."));

        private IWebElement PasswordNotMatchingError => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("repeatedPassword.errors")));

        private IWebElement UsernameExistsError => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("customer.username.errors")));

        private IWebElement RequiredFieldError => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//span[@class='error' and text()='{errorList[emptyField]}']")));

        
        private IWebElement btnRegister => RegistrationForm.FindElement(By.XPath(".//input[@value='Register']"));


        public WelcomePage SubmitAndContinue()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(btnRegister)).Click();
            return new WelcomePage(Driver);
        }


        public RegisterPage Submit()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(btnRegister)).Click();
            return this;
        }

        public bool VerifyRegistrationFormDisplayed()
        {

            try
            {
                return WelcomeMessage.Displayed;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        


        public RegisterPage FillOutTheForm()
        {

            foreach (IWebElement el in FieldsList)
            {
                el.FindElement(By.XPath(".//input")).SendKeys(CommonFunctions.RandomString(5));
            }

            return this;

        }

        public RegisterPage FillOutTheFormExcept(string name)
        {

            foreach (IWebElement el in FieldsList)
            {
                string field_name = el.FindElement(By.XPath("./td[1]/b")).Text;

                if (field_name.Contains(name) == false)
                    el.FindElement(By.XPath(".//input")).SendKeys(CommonFunctions.RandomString(5));
              
            }
            emptyField = name;
            return this;

        }


        public RegisterPage FillinTheField(string name, string value)
        {

            foreach (IWebElement el in FieldsList)
            {
                string field_name = el.FindElement(By.XPath("./td[1]/b")).Text;

                if (field_name.Contains(name))
                {
                    el.FindElement(By.XPath(".//input")).Clear();
                    el.FindElement(By.XPath(".//input")).SendKeys(value);
                }
            }
            return this;

        }


        public bool VerifyPasswordNotMatchingErrorDisplayed()
        {

            try
            {
                return PasswordNotMatchingError.Displayed;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }


        public bool VerifyRequiredFieldMessageDisplayed()
        {

            try
            {
                return RequiredFieldError.Displayed;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }


        public bool VerifyUsernameExistsMessageDisplayed()
        {

            try
            {
                return UsernameExistsError.Displayed;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

    }
}