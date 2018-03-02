using CiklumTestTask.Helpers;
using CiklumTestTask.PageObjects;
using NUnit.Framework;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace CiklumTestTask
{
    //BDD steps implementation
    [Binding]
    public class BDD_ExampleSteps
    {
        [AfterFeature]
        public static void CleanUp()
        {
            DriverHelper.Instance.CloseDriver();
        }

        [Given(@"Booking\.com was opened")]
        public void GivenBooking_ComWasOpened()
        {
            DriverHelper.Instance.Driver.Navigate().GoToUrl("https://www.booking.com");
        }
        
        [Given(@"Language was changed to English")]
        public void GivenLanguageWasChangedToEnglish()
        {
            MainPage.Instance.ChangeLanguageToEnglish();
        }
        
        [Given(@"Currency was changed to Euro")]
        public void GivenCurrencyWasChangedToEuro()
        {
            MainPage.Instance.ChangeCurrencyToEuro();
        }
        
        [Given(@"Location was set to ""(.*)""")]
        public void GivenLocationWasSetTo(string location)
        {
            MainPage.Instance.InputInSearch(location);
        }
        
        [Given(@"Check in date is last day of the month")]
        public void GivenCheckInDateIsLastDayOfTheMonth()
        {
            MainPage.Instance.InputCheckinInLastDate();
        }
        
        [Given(@"Adult persont is ""(.*)""")]
        public void GivenAdultPersontIs(int count)
        {
            MainPage.Instance.SelectAdults(count);
        }
        
        [Given(@"Child is ""(.*)""")]
        public void GivenChildIs(int count)
        {
            MainPage.Instance.SelectChildren(count);
        }
        
        [Given(@"Child age is ""(.*)""")]
        public void GivenChildAgeIs(int age)
        {
            MainPage.Instance.SelectChildAge(age);
        }
        
        [Given(@"There should be ""(.*)"" rooms")]
        public void GivenThereShouldBeRooms(int count)
        {
            MainPage.Instance.SelectRooms(count);
        }
        
        [Given(@"It is business trip")]
        public void GivenItIsBusinessTrip()
        {
            MainPage.Instance.CheckForWorkCheckBox();
        }
        
        [When(@"User try to search hotel according requirements")]
        public void WhenUserTryToSearchHotelAccordingRequirements()
        {
            MainPage.Instance.ClickSearchButton();
        }
        
        [Then(@"There is at leest one hote with rating more than (.*) and price lower than (.*) euros")]
        public void ThenThereIsAtLeestOneHoteWithRatingMoreThanAndPriceLowerThanEuros(int p0, int p1)
        {
            string hotelName = ResultPage.Instance.AreHotelsPresentWithRatingMoreThanAndPriceLowerThan(8,200);
            Assert.IsNotNull(hotelName, "There is no hotel mutched params");
            //using Scenario context to share hotel name between steps
            ScenarioContext.Current.Add("hotel", hotelName);
        }
        
        [Then(@"Name of the first matched hotel should be shown in console log")]
        public void ThenNameOfTheFirstMatchedHotelShouldBeShownInConsoleLog()
        {
            string hotelName = ScenarioContext.Current.Get<string>("hotel");

            Console.WriteLine(hotelName);
        }
    }
}
