Feature: CasesOverview
	In order to keep the cases organized
	As a user
	I want to be shown the cases correctly sorted and with the correct information
	
@mytag
Scenario: Cases overview: correct columns
	Given I am in the Overview screen
	When I go to the Cases overview screen
	Then the cases grid with the correct columns is displayed

Scenario: Cases overview: cases sorted by creation time
	Given I am in the Overview screen
	When I go to the Cases overview screen
	Then cases are sorted by creation time

	Scenario: Search a valid Serial number which is existing in the list
	Given I am in the Overview screen
	And I create two duplicate cases and a different case
	When I search by SerialNumber of the duplicate cases
	Then the only two cases with the same SerialNumber I created are displayed

	Scenario: Search a valid Customer value which is existing in the list
	Given I am in the Overview screen
	And I create two duplicate cases and a different case
	When I search by Customer of the duplicate cases
	Then the only two cases with the same Customer I created are displayed

	Scenario: Search a valid Country value which is existing in the list
	Given I am in the Overview screen
	And I create two duplicate cases and a different case
	When I search by Country of the duplicate cases
	Then the only two cases with the same Country I created are displayed

	Scenario: Search a valid CaseId value which is existing in the list
	Given I am in the Overview screen
	And I create two duplicate cases and a different case
	When I search by CaseId of the duplicate cases
	Then the only two cases with the same CaseId I created are displayed
