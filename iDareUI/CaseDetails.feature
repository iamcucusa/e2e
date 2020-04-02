Feature: CaseDetails
	In order to 
	As a 
	I want to 

@ignore
Scenario: Information in Instrument Information section is shown
	Given I am in the Overview screen
	When I create a new Case
		And I enter to the details of a case
	Then the Instrument Information should be shown under the Instrument Information section
