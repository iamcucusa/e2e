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

Scenario: 635 Display Lab and instrument information
	Given I am in the Overview screen
		And I enter to create a new case
	When I enter CAS-1122334455 as Rexis ID
		And I enter WSIM001234 as Serial number
		And I enter ศูนย์บริการโลหิตแห่งชาติ สภากาชาดไทย as Customer
		And I enter UNITED ARAB EMIRATES as Country
		And I enter the option 2 of the dropdown as Timezone
		And I upload a Problem Report with name ProblemReport_OnlySummary.zip
		And I press the Save button
		And all files of the CAS-1122334455 case have been processed
	Then I enter to the details of a case
	Then the Instrument Information should be shown under the Instrument Information section
	Then The user navigates to the investigation view
		And the Instrument Information should be shown under the Instrument Information section

Scenario: 1962 Display information about performed runs

