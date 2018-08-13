using EqualExpertsAutomationProject.ObjectRepository;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System;
using System.Collections.Generic;

namespace EqualExpertsAutomationProject.PageObjects
{
    public partial class BookingFormPage
    {
        //members of the class used to locator page elements
        private IWebDriver _driver;
        private By _firstname = By.Id("firstname");
        private By _surname = By.Id("lastname");
        private By _price = By.Id("totalprice");
        private By _deposit = By.Id("depositpaid");
        private By _checkin = By.Id("checkin");
        private By _checkout = By.Id("checkout");
        private By _bookingcount = By.XPath("//*[@id='bookings']/*[@class='row']/following-sibling::div");
        private By _save = By.XPath("//input[contains(@value,' Save ')]");

        // A patial class is used to used to split out the actions from the variables allowing for better readability.

        //Constructor 
        public BookingFormPage(IWebDriver driver)
        {
            _driver = driver;
        }

        //NavigateToBookFormPage is to go the url address.
        public void NavigateToBookFormPage()
        {
            try
            {
                _driver.Navigate().GoToUrl(ObjectRepositories.IConfig.GetWebSiteAddress());
            }
            catch (WebDriverException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //EnterFirstName is used to key in first name.
        public BookingFormPage EnterFirstName(string name)
        {
            try
            {
                var firstname = _driver.FindElement(_firstname);
                firstname.Clear();
                firstname.SendKeys(name);
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e.Message);
            }

            return this;
        }

        //EnterSurname is used to key in surname.
        public BookingFormPage EnterSurname(string name)
        {
            try
            {
                var surname = _driver.FindElement(_surname);
                surname.Clear();
                surname.SendKeys(name);
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e.Message);
            }

            return this;
        }

        //EnterPrice method is used to key in the price.
        public BookingFormPage EnterPrice(string price)
        {
            try
            {
                var prices = _driver.FindElement(_price);
                prices.Clear();
                prices.SendKeys(price);
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e.Message);
            }

            return this;
        }

        // SelectDeposit method is used to choose the deposit option
        public BookingFormPage SelectDeposit(string deposit)
        {
            try
            {
                SelectElement select = new SelectElement(_driver.FindElement(_deposit));
                select.SelectByText(deposit);
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e.Message);
            }

            return this;
        }

        //EnterCheckInDate method is used to key in the check-in date
        public BookingFormPage EnterCheckInDate(string checkindate)
        {
            try
            {
                var checkin = _driver.FindElement(_checkin);
                checkin.Clear();
                checkin.SendKeys(checkindate);

            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e.Message);
            }

            return this;
        }

        //EnterCheckOutDate method is used to key in the check-out date
        public BookingFormPage EnterCheckOutDate(string checkoutdate)
        {
            try
            {
                var checkout = _driver.FindElement(_checkout);
                checkout.Clear();
                checkout.SendKeys(checkoutdate);

            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e.Message);
            }

            return this;
        }

        //TheTotalNumberOfRowsInTheBookingList returns the number reconds in the booking list form
        public int TheTotalNumberOfRowsInTheBookingList(string message)
        {
            //The store the list using the collection IList
            IList<IWebElement> BookingRows = _driver.FindElements(_bookingcount);

            //Assign the count of the varibale numberOfBookingRows 
            int numberOfBookingRows = BookingRows.Count;

            Console.WriteLine(message+" "+ numberOfBookingRows);
            return numberOfBookingRows;


        }


        //ClickOnSave clicks on th save button
        public BookingFormPage ClickOnSave()
        {
            try
            {
                var save = _driver.FindElement(_save);
                save.Click();

            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e.Message);

            }
            return this;
        }

        //ClickOnDelete clicks the delete button for specfic entry based on the booking row id
        public BookingFormPage ClickOnDelete(int deletebuttonnumber)
        {
            try
            {
                // driver.FindElement(By.XPath("//input[@onclick='deleteBooking(42601)']"));
                //  "//div[@id='bookings']/div[" + deletebuttonnumber.ToString() + "]//input[@value='Delete']"

                //input[contains(@onclick,'deleteBooking(42601)')]
                //div[@id='bookings']/div[2]//input[@value='Delete']

                ++deletebuttonnumber;

                var wait = new WebDriverWait(ObjectRepositories.Driver, TimeSpan.FromSeconds(60));
                wait.PollingInterval = TimeSpan.FromMilliseconds(2000);
                wait.Timeout = TimeSpan.FromSeconds(40);

                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='bookings']/div["+deletebuttonnumber+"]//input[@value='Delete']"))).Click();

                //var _lastdeletebutton = _driver.FindElement(By.XPath("//div[@id='bookings']/div["+deletebuttonnumber+"]//input[@value='Delete']"));
               // _lastdeletebutton.Click();

            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e.Message);

            }
            return this;
        }




    }

}

