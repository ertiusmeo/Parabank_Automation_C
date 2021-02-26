using DarekTest.Base;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;


namespace DarekTest.Pages
{
    public class WelcomePage : BasePage
    {
        public WelcomePage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement btnLogout => Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[contains(text(),'Log Out')]")));
        private IWebElement WelcomeMessage => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//b[contains(text(),'Welcome')]")));

        private IWebElement SuccessMessage => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[contains(text(),'Your account was created successfully. You are now logged in.')]")));

        public bool VerifyWelcomeMessageDisplayed()
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

        public bool VerifySuccessMessageDisplayed()
        {

            try
            {
                return SuccessMessage.Displayed;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }


        public WelcomePage Logout()
        {
            btnLogout.Click();
            return this;
        }
    }
}