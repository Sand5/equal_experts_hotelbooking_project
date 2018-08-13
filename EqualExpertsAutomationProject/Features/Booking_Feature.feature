Feature: BookingFeature
	In order to manage hotel bookings
	As a user of the booking system
	I want to be able to create and delete bookings

    Background: The user has navigated to the booking form pages
    Given I am on the hotel booking form 

    Scenario: Create a vaild hotel booking 
	When I enter a firstname,surname
	| FirstName | Surname |
	| Constantine| Constantine|
	And  I enter a price with deposit selection
	| Price | Deposit |
	| 5000   | false    |
	And  I enter both check-in with check-out dates
	| Check-In   | Check-Out  |
	| 2018-08-08 | 2018-08-09 |
	Then I press the save button checking the booking is saved to the list
	

	Scenario: Delete a vaild hotel booking
	When I create a vaild hotel booking 
	| FirstName | Surname | Price | Deposit | Check-In   | Check-Out  |
	|Constantine | Taggart | 400   | false   | 2018-08-09 | 2018-08-11 |
	Then I delete my booking and the booking is deleted