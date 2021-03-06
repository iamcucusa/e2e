﻿Feature: CaseCreation
	In order to create a new case
	As a customer
	I want to be prevented from leaving empty fields before saving


@mytag
Scenario: User does not enter mandatory fields when creating a new case
		Given I am in the Overview screen
		And I enter to create a new case
	When I enter Customer as Customer
		And I enter A1234 as Serial number
		And I enter Spain as Country
		But I leave the ID field empty
	Then the Save button is disabled

@filesUploadingCases
Scenario: 203 Create a new case and manually select a file
		Given I am in the Overview screen
		And I enter to create a new case
	When I enter Customer as Customer
		And I enter a Rexis ID with a unique ID
		And I enter A1234 as Serial number
		And I enter Spain as Country
		And I enter the option 1 of the dropdown as Timezone
		And I upload a Problem Report with name RealDataSmall.zip
		And I press the Save button
	Then I should see the progress of the 1 uploads
		And the case with the unique ID as Rexis ID is on the top of the list

@filesUploadingCases
Scenario: 204 Create a new case and manually select multiple files
		Given I am in the Overview screen
		And I enter to create a new case
	When I enter Customer as Customer
		And I enter a Rexis ID with a unique ID
		And I enter A1234 as Serial number
		And I enter Spain as Country
		And I enter the option 1 of the dropdown as Timezone
		And I upload a Problem Report with name RealDataSmall.zip,RealDataSmall2.zip
		And I press the Save button
	Then I should see the progress of the 2 uploads
		And the case with the unique ID as Rexis ID is on the top of the list
	Then The progress of the uploads should disappear
	
Scenario: 205 Create a new case and manually select a file and cancel the operation
	Given I am in the Overview screen
		And I enter to create a new case
	When I enter Customer as Customer
		And I enter a Rexis ID with a unique ID
		And I enter A1234 as Serial number
		And I enter Spain as Country
		And I enter the option 1 of the dropdown as Timezone
		And I upload a Problem Report with name RealDataSmall.zip
		And I press the Cancel button
	Then I should not see any upload progress bars


@filesUploadingCases
Scenario: 746 Create a new case and manually select multiple files
	Given I am in the Overview screen
		And I enter to create a new case
	When I enter Customer as Customer
		And I enter a Rexis ID with a unique ID
		And I enter A1234 as Serial number
		And I enter Spain as Country
		And I enter the option 1 of the dropdown as Timezone
		And I press the Save button
	Then The case creation dialog is closed
	When I enter the RexisId in the filter
	Then The case is displayed in the list with the RexisId
	Then I click the edit case button for the first case
		When I upload a Problem Report with name RealDataSmall.zip
		And I press the Save button
		Then The case creation dialog is closed
	Then I should see the progress of the 1 uploads
	Then The progress of the uploads should disappear
		When I enter the RexisId in the filter
		Then I click the edit case button for the first case
		When I upload a Problem Report with name RealDataSmall2.zip,RealDataSmall3.zip
		And I press the Save button
		Then I should see the progress of the 2 uploads
	Then The progress of the uploads should disappear
		When I enter the RexisId in the filter
		Then The case is displayed in the list with the RexisId
		Then I click the edit case button for the first case
		When I upload a Problem Report with name test.txt,settings.xml,IM.Backend.log
		Then The files list shows the files I have added test.txt,settings.xml,IM.Backend.log
		Then I remove a file test.txt
		When I press the Save button
		Then I should see the progress of the 2 uploads
		Then The progress of the uploads should disappear
		Then The Progress Shows Updated Status Success

@ignore
Scenario: New cases are placed on the top of the first page of the cases overview
		Given I am in the Overview screen
		Given there are at least 20 cases created
		And I navigate to the next case page 
		And I create a new case without problem report
	Then the first page of the cases overview is shown
		And the case with the unique ID as Rexis ID is on the top of the list

Scenario: Uploaded files have their status shown in real time successful
		Given I am in the Overview screen
			And I enter to create a new case
		When I enter Customer as Customer
			And I enter A1234 as Serial number
			And I enter Spain as Country
			And I enter a Rexis ID with a unique ID
			And I enter the option 1 of the dropdown as Timezone
			And I upload a Problem Report with name RealDataSmall.zip
			And I press the Save button
		Then I should see the progress of the 1 uploads
			And the status gets updated as successful

Scenario: Uploaded files have their status shown in real time error
		Given I am in the Overview screen
			And I enter to create a new case
		When I enter Customer as Customer
			And I enter A1234 as Serial number
			And I enter Spain as Country
			And I enter a Rexis ID with a unique ID
			And I enter the option 1 of the dropdown as Timezone
			And I upload a Problem Report with name RealDataSmallFail.zip
			And I press the Save button
		Then I should see the progress of the 1 uploads
			And the status gets updated as error

@filesUploadingCases @ignore
Scenario: Multiple files are uploaded to more than one case showing the correct status bars
		Given I am in the Overview screen
			And I enter to create a new case
		When I enter Customer as Customer
			And I enter A1234 as Serial number
			And I enter Spain as Country
			And I enter a Rexis ID with a unique ID
			And I enter the option 1 of the dropdown as Timezone
			And I upload a Problem Report with name RealDataSmall.zip , RealDataSmall2.zip
			And I press the Save button
		Then I should see the progress of the 2 uploads
		Given I enter to create a new case
		When I enter Customer1 as Customer
			And I enter A12345 as Serial number
			And I enter SWitzerland as Country
			And I enter a Rexis ID with a unique ID
			And I enter the option 2 of the dropdown as Timezone
			And I upload a Problem Report with name RealDataSmall.zip , RealDataSmall2.zip
			And I press the Save button
		Then I should see the progress of the 4 uploads