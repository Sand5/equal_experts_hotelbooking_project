using EqualExpertsAutomationProject.ObjectRepository;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System;


namespace EqualExpertsAutomationProject.Helpers
{
    public class WaitForBookingOnListHelper
    {

        //Waits for the new booking row to be displayed 
        public static void WaiTforNewBookingToDisplay(int listnumber)
        {
            //Increment the booking list based on the count before the save
            var num = ++listnumber;

            //Create new WebDriverWait object
            var wait = new WebDriverWait(ObjectRepositories.Driver, TimeSpan.FromSeconds(60));
            wait.PollingInterval = TimeSpan.FromMilliseconds(2000);
            wait.Timeout = TimeSpan.FromSeconds(40);
            try
            {
                //Wait for the new added booking row to be visable
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='bookings']/*[@class='row']/following-sibling::div[position()=" + num + "]")));

                //Extract the new added rows unquie add
                var ele = ObjectRepositories.Driver.FindElement(By.XPath("//*[@id='bookings']/*[@class='row']/following-sibling::div[position()=" + num + "]")).GetAttribute("id");

                //Wait for the delete button to appear to completely ensure the new booking row is displayed 
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@onclick='deleteBooking(" + ele + ")']")));
            }catch (NoSuchElementException e)
            {
                Console.WriteLine(e.Message);
            }
            //input[@onclick='deleteBooking(42484)']
        }
    }
}
