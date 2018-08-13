using EqualExpertsAutomationProject.ObjectRepository;
using EqualExpertsAutomationProject.PageObjects;
using EqualExpertsAutomationProject.UtilityHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using EqualExpertsAutomationProject.Helpers;

namespace EqualExpertsAutomationProject.StepDefinitions
{
    [Binding]
    public class BookingFeatureSteps
    {

        //The Step definintions file used to turn the feature file steps into concreate action.

        //The variables will be used to store a count of bookings on the booking form.
        private int bookingListCountBefore;
        private int bookingListCountCountAfter;

        [Given(@"I am on the hotel booking form")]
        public void GivenIAmOnTheHotelBookingForm()
        {
            //Create the booking form page object.
            ObjectRepositories.BookingForm = new BookingFormPage(ObjectRepositories.Driver);

            //Navigate to the booking form.
            ObjectRepositories.BookingForm.NavigateToBookFormPage();
        }

        [When(@"I enter a firstname,surname")]
        public void WhenIEnterAFirstnameSurname(Table table)
        {
            //Enter in the first and surname data using the data table supplied in the feature file.
            foreach (var row in table.Rows)
            {
                ObjectRepositories.BookingForm
                                  .EnterFirstName(row["FirstName"])
                                  .EnterSurname(row["Surname"]);

            }
        }

        [When(@"I enter a price with deposit selection")]
        public void WhenIEnterAPriceWithDepositSelection(Table table)
        {
            //Enter in the price data using the data table supplied in the feature file.
            foreach (var row in table.Rows)
            {
                ObjectRepositories.BookingForm
                                  .EnterPrice(row["Price"])
                                   .SelectDeposit(row["Deposit"]);
            }
        }

        [When(@"I enter both check-in with check-out dates")]
        public void WhenIEnterBothCheck_InWithCheck_OutDates(Table table)
        {
            //Enter in the check-in and check-out data using the data table supplied in the feature file.
            foreach (var row in table.Rows)
            {
                ObjectRepositories.BookingForm
                              .EnterCheckInDate(row["Check-In"])
                              .EnterCheckOutDate(row["Check-Out"]);

            }
        }

        [When(@"I create a vaild hotel booking")]
        public void WhenICreateAVaildHotelBooking(Table table)
        {
            //Enter in all mandatory data using the data table supplied in the feature file for creating a booking and save the booking. 
            foreach (var row in table.Rows)
            {
                ObjectRepositories.BookingForm
                                  .EnterFirstName(row["FirstName"])
                                  .EnterSurname(row["Surname"])
                                  .EnterPrice(row["Price"])
                                  .SelectDeposit(row["Deposit"])
                                  .EnterCheckInDate(row["Check-In"])
                                  .EnterCheckOutDate(row["Check-Out"]);

                ObjectRepositories.BookingForm.ClickOnSave();

                //Refresh the page.
                WindowHelper.RefreshThePage();
                bookingListCountBefore = ObjectRepositories.BookingForm.TheTotalNumberOfRowsInTheBookingList("The number of booking rows after saving a new is:");
            }
        }

        [Then(@"I press the save button checking the booking is saved to the list")]
        public void ThenIPressTheSaveButtonCheckingTheBookingIsSavedToTheList()
        {
            //Get the booking list count from the booking form page before saving the booking.
            bookingListCountBefore = ObjectRepositories.BookingForm.TheTotalNumberOfRowsInTheBookingList("The number of booking rows before saving is:");

            //Save the booking.
            ObjectRepositories.BookingForm.ClickOnSave();
       
            WaitForBookingOnListHelper.WaiTforNewBookingToDisplay(bookingListCountBefore);
            

            //Get the booking list count from the booking form after the save and refresh action has taken place.
            bookingListCountCountAfter = ObjectRepositories.BookingForm.TheTotalNumberOfRowsInTheBookingList("The number of booking rows afetr saving is:");

            //Check the before and after counts of the booking ilst are not the same.
            Assert.AreNotEqual(bookingListCountBefore, bookingListCountCountAfter);


        }


        [Then(@"I delete my booking and the booking is deleted")]
        public void ThenIDeleteMyBookingAndTheBookingIsDeleted()
        {
            //Get the booking list count from the booking form page before saving the booking.
            bookingListCountBefore = ObjectRepositories.BookingForm.TheTotalNumberOfRowsInTheBookingList("The number of booking rows after saving a new is:");

            //Delete the booking based on the last number in the booking list.
            ObjectRepositories.BookingForm.ClickOnDelete(bookingListCountBefore);

            //Refresh the page 
            WindowHelper.RefreshThePage();

            //Check the before and after counts of the booking ilst are not the same.
            bookingListCountCountAfter = ObjectRepositories.BookingForm.TheTotalNumberOfRowsInTheBookingList("The number of booking rows after deleting is:");

            

            //Get the booking list count from the booking form after the delete and refresh action has taken place.
            Assert.AreNotEqual(bookingListCountBefore, bookingListCountCountAfter);


        }
    }
}
