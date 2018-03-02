#Simple BDD test
Feature: BDD_Example

Scenario: BDD Check Hotels Test
	Given Booking.com was opened
	And Language was changed to English
	And Currency was changed to Euro
	And Location was set to "Málaga, Andalucía, Spain"
	And Check in date is last day of the month
	And Adult persont is "1"
	And Child is "1"
	And Child age is "5"
	And There should be "2" rooms
	And It is business trip
	When User try to search hotel according requirements
	Then There is at leest one hote with rating more than 8 and price lower than 200 euros
	And Name of the first matched hotel should be shown in console log
