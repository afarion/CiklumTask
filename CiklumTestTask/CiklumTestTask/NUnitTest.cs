using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;
using CiklumTestTask.Helpers;
using CiklumTestTask.PageObjects;

namespace CiklumTestTask
{
    //Nunit test example
    [TestFixture]
    public class NUnitTest
    {
        [OneTimeSetUp]
        public void Setup()
        {
            DriverHelper.Instance.Driver.Navigate().GoToUrl("https://www.booking.com");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            DriverHelper.Instance.CloseDriver();
        }

       [Test]
       public void NUnit_CheckHotelsTest()
        {
            MainPage.Instance.ChangeLanguageToEnglish()
                .ChangeCurrencyToEuro()
                .InputInSearch("Málaga, Andalucía, Spain")
                .InputCheckinInLastDate()
                .SelectAdults(1)
                .SelectChildren(1)
                .SelectChildAge(5)
                .SelectRooms(2)
                .CheckForWorkCheckBox()
                .ClickSearchButton();

            string hotelName = ResultPage.Instance.AreHotelsPresentWithRatingMoreThanAndPriceLowerThan(8,200);
            Assert.IsNotNull(hotelName, "There is no hotel mutched params");
            //you can find console output in test results output
            Console.WriteLine(hotelName);
        }
    }
}
