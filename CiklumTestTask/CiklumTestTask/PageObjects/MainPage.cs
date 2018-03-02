using CiklumTestTask.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiklumTestTask.PageObjects
{
    //Page Object implementation
    class MainPage
    {
        //it is not Singleton, just static instance to simplify call of page
        //you can find Singleton implementation in DriverHelper class
        private static MainPage instance = null;

        public static MainPage Instance
        {
            get
            {
                if (instance == null)
                    instance = new MainPage();
                return instance;
            }
            set
            {
                instance = value;
            }
        }
        
        public MainPage()
        {
            PageFactory.InitElements(DriverHelper.Instance.Driver, this);
        }

        // Selenium Page Factory to call simple elements
        //Searching by XPath
        [FindsBy(How = How.XPath, Using = "//*[@data-id='language_selector']")]
        private IWebElement ChangeLangugeButton;
        //Searching by ClassName
        [FindsBy(How = How.ClassName, Using = "lang_en-us")]
        private IWebElement EnglishLanguageItem;

        [FindsBy(How = How.XPath, Using = "//*[@data-id='currency_selector']")]
        private IWebElement ChangeCurrencyButton;
        //Searching by Id
        [FindsBy(How = How.Id, Using = "ss")]
        private IWebElement SearchField;

        [FindsBy(How = How.XPath, Using = "//*[@data-label='Málaga, Andalucía, Spain']")]
        private IWebElement AutocompleteAddress;

        [FindsBy(How = How.XPath, Using = "//*[@data-id='1522454400000']")]
        private IWebElement LastDayCurrentMonth;

        [FindsBy(How = How.Id, Using = "group_adults")]
        private IWebElement AdultSelector;

        [FindsBy(How = How.Id, Using = "group_children")]
        private IWebElement ChildrenSelector;

        [FindsBy(How = How.XPath, Using = "//select[@name='age']")]
        private IWebElement ChildAgeSelector;

        [FindsBy(How = How.Id, Using = "no_rooms")]
        private IWebElement RoomsSelector;

        [FindsBy(How = How.XPath, Using = "//input[@name='sb_travel_purpose']")]
        private IWebElement ForWorkCheckbox;

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        private IWebElement SearchButton;

        //geter to call element requied additional wait
        private IWebElement EuroItem
        {
            get
            {
                return ElementsHelper.FindElementWait(By.ClassName("currency_EUR"));
            }
        }

        //Actions with elements presents bellow
        public MainPage ChangeLanguageToEnglish()
        {
            ChangeLangugeButton.Click();
            EnglishLanguageItem.Click();
            return this;
        }

        public MainPage ChangeCurrencyToEuro()
        {
            ChangeCurrencyButton.Click();
            EuroItem.Click();
            return this;
        }

        public MainPage InputInSearch(string search)
        {
            SearchField.SendKeys(search);
            AutocompleteAddress.Click();
            return this;
        }

        public MainPage InputCheckinInLastDate()
        {
            LastDayCurrentMonth.Click();
            return this;
        }

        public MainPage SelectAdults(int n)
        {
            AdultSelector.SendKeys(string.Format("{0} adult", n.ToString()));
            return this;
        }

        public MainPage SelectChildren(int n)
        {
            ChildrenSelector.SendKeys(string.Format("{0} child", n.ToString()));
            return this;
        }

        public MainPage SelectChildAge(int n)
        {
            ChildAgeSelector.SendKeys(string.Format("{0} year", n.ToString()));
            return this;
        }

        public MainPage SelectRooms(int n)
        {
            RoomsSelector.SendKeys(string.Format("{0} room", n.ToString()));
            return this;
        }

        public MainPage CheckForWorkCheckBox()
        {
            ForWorkCheckbox.Click();
            return this;
        }

        public ResultPage ClickSearchButton()
        {
            SearchButton.Click();
            return ResultPage.Instance;
        }
    }
}
