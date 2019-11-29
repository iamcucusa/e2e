Feature: CasesOverview
	In order to keep the cases organized
	As a user
	I want to be shown the cases correctly sorted and with the correct information

@mytag
Scenario: Cases overview: correct columns
	Given I am logged in as teacher
	When I go to the Cases overview screen
	Then the cases grid with the correct columns is displayed

Scenario: Cases overview: cases sorted by creation time
	Given I am logged in as teacher
	When I go to the Cases overview screen
	Then cases are sorted by creation time

	Scenario: Search a valid Serial number which is existing in the list
	Given Cases are present with different entries
	And I type in the search bar a valid Serial number
	When I press the search icon
	Then only the cases with that serial number are displayed
