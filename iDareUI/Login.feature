Feature: Login
	In order to access the application main screen
	As a user
	I want to login with the correct user name and password

@mytag
Scenario: User teacher login
	Given I am in the Login screen
		And I enter the username teacher
		And I enter the password Whatever
	When I login
	Then I should see the Cases screen for teacher

Scenario: User investigator login
	Given I am in the Login screen
		And I enter the username investigator
		And I enter the password Whatever
	When I login
	Then I should see the Cases screen for investigator

Scenario: Invalid user login
	Given I am in the Login screen
		And I enter the username customer
		And I enter the password Whatever
	When I login
	Then I should an error message


