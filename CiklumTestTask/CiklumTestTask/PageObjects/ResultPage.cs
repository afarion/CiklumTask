using CiklumTestTask.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiklumTestTask.PageObjects
{
    //Page Object implementation
    class ResultPage
    {
        //it is not Singleton, just static instance to simplify call of page
        //you can find Singleton implementation in DriverHelper class
        private static ResultPage instance = null;
        public static ResultPage Instance
        {
            get
            {
                if (instance == null)
                    instance = new ResultPage();
                return instance;
            }
            set
            {
                instance = value;
            }
        }

        public ResultPage()
        {
            PageFactory.InitElements(DriverHelper.Instance.Driver, this);
        }
        
        //Getting all hotels were found
        public ReadOnlyCollection<IWebElement> Hotels
        {
            get
            {
                return DriverHelper.Instance.Driver.FindElements(By.XPath("//div[@id='hotellist_inner']/div"));
            }
        }

        //Method to check required conditions
        public string AreHotelsPresentWithRatingMoreThanAndPriceLowerThan(double rate, double expectedPrice)
        {
            foreach (var hotel in Hotels)
            {
                double rating;
                //filter hotels without rating
                try
                {
                    rating = Convert.ToDouble(hotel.GetAttribute("data-score"));
                }
                catch
                {
                    rating = 0;
                }

                if(rating>rate)
                {
                    //getting price
                    IWebElement priceEl = hotel.FindElement(By.XPath("//div[contains(@class, 'totalPrice')]"));
                    string price = priceEl.Text;
                    price = price.Substring(price.IndexOf('€') + 2);
                    if (Convert.ToDouble(price) < expectedPrice)
                    {
                        //return first hotel matched conditions
                        return hotel.FindElement(By.XPath("//span[contains(@class, 'sr-hotel__name')]")).Text;
                    }
                }
            }
            //return null if no matched hotels found
            return null;
        }
    }
}
