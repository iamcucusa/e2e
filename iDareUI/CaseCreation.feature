﻿Feature: CaseCreation
	In order to create a new case
	As a customer
	I want to be prevented from leaving empty fields before saving

@mytag
Scenario: User does not enter mandatory fields when creating a new case
	Given I am logged in as teacher
		And I enter to create a new case
	When I enter Customer as Customer
		And I enter A1234 as Serial number
		And I enter Spain as Country
		But I leave the ID field empty
	Then the Save button is disabled
	
Scenario: New cases are placed on the top of the first page of the cases overview
		Given I am logged in as investigator
		Given there are at least 10 cases created
		And I navigate to the next case page 
		And I create a new case without problem report
	Then the first page of the cases overview is shown
		And the case with the unique ID as Rexis ID is on the top of the list


	
