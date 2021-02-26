using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DarekTest.Base
{

    public class BaseTest
    {

        [TestInitialize]
        public void Setup()
        {

            Driver = new ChromeDriver(Providers.Providers.startupPath+"\\");
            Driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void TearDown()
        {
            Driver.Quit();
        }

        protected IWebDriver Driver { get; set; }
    }
}