using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace DarekTest.Base
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;
        public WebDriverWait Wait;
        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
    }
}