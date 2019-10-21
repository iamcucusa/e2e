Feature: CaseCreation
	In order to create a new case
	As a customer
	I want to be prevented from leaving empty fields before saving

@mytag
Scenario: User does not enter mandatory fields when creating a new case
	Given I am logged in as teacher
		And I enter to create a new case
	When I enter ABCD1234 as Rexis ID
		And I enter A1234 as Serial number
		And I enter 1.1 as Software Version
		And I enter Spain as Country
		But I leave the Customer field empty
	Then the Save button is disabled
	