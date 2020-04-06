Feature: CaseDetails
	In order to 
	As a 
	I want to 

@ignore
Scenario: Information in Instrument Information section is shown
	Given I am in the Overview screen
	When I create a new Case
		And I enter to the details of a case
	Then the titles shown in the Details of the case are correct
	And the Instrument Information should be shown under the Instrument Information section

Scenario: 55 Information in Instrument Information section is shown
	Given I am in the Overview screen
	When I create a new Case
	Then the system shall fill the case fields automatically
