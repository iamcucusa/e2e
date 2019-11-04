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
		And I enter Spain as Country
		But I leave the Customer field empty
	Then the Save button is disabled
	
Scenario: New cases are placed on the top of the first page of the cases overview
	Given I am logged in as investigator
		And I navigate to the next case page 
		And I enter to create a new case
	When I enter a Rexis ID with a unique ID
		And I enter A1234 as Serial number
		And I enter Customer as Customer
		And I enter Spain as Country
		And I press the Save button
	Then the first page of the cases overview is shown
		And the case with the unique ID as Rexis ID is on the top of the list
