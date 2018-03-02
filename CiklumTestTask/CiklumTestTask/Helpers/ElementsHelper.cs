using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiklumTestTask.Helpers
{
    //In this class we can implement additional methods to work with elements, eg explicit wait of control, or some additional action eg. swipe, drag&drop etc
    public class ElementsHelper
    {
        //Explicit wait of control
        public static IWebElement FindElementWait(By condition)
        {
            int timeout = Convert.ToInt32(ConfigurationManager.AppSettings["timeoutInSeconds"]);
            WebDriverWait wait = new WebDriverWait(DriverHelper.Instance.Driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(ExpectedConditions.ElementToBeClickable(condition));
        }
    }
}
