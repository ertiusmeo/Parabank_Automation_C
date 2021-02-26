using DarekTest.Base;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;


namespace DarekTest.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement txtUsername => Driver.FindElement(By.XPath("//input[@name='username']"));
        private IWebElement txtPassword => Driver.FindElement(By.XPath("//input[@name='password']"));
        private IWebElement btnLogin => Driver.FindElement(By.XPath("//input[@value='Log In']"));
        private IWebElement btnRegister => Driver.FindElement(By.XPath("//a[contains(text(),'Register')]"));
        private IWebElement ErrorMessage => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[contains(text(),'Please enter a username and password.')]")));



        public LoginPage Go()
        {
            Driver.Navigate().GoToUrl(Providers.Providers.Login);
            return this;
        }

        public LoginPage EnterCredentials(string login, string password)
        {
            txtUsername.SendKeys(login);
            txtPassword.SendKeys(password);
            return this;
        }

        public LoginPage Submit()
        {
            btnLogin.Click();
            return this;
        }

        public RegisterPage Register()
        {
            btnRegister.Click();
            return new RegisterPage(Driver);
        }


        public bool VerifyErrorMessageDisplayed()
        {

            try
            {
                return ErrorMessage.Displayed;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }


    }
}