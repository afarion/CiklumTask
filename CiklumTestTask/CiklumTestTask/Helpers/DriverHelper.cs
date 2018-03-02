using CiklumTestTask.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiklumTestTask.Helpers
{
    public class DriverHelper
    {
        #region Singleton
        // Here you can find implementation of singleton pattern to have just one instance of selenium driver
        private static DriverHelper instance = null;
        // private constructor
        private DriverHelper(){ }
        public static DriverHelper Instance
        {
            get
            {
                if (instance == null)
                    instance = new DriverHelper();
                return instance;
            }
        }

        private IWebDriver driver = null;
        public IWebDriver Driver
        {
            get
            {
                if (driver == null)
                {
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--start-maximized");
                    driver = new ChromeDriver(TestContext.CurrentContext.TestDirectory,options);
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                }
                return driver;
            }
        }

        #endregion
        //Disposing driver to prevent exception that port is under usage
        public void CloseDriver()
        {
            driver.Close();
            driver.Quit();
            driver.Dispose();
            //also I am clearing here static instances of pages
            MainPage.Instance = null;
            ResultPage.Instance = null;
            driver = null;
        }
    }
}
