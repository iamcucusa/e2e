Feature: CasesOverview
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Cases overview: correct columns
	Given I am logged in as teacher
	When I go to the Cases overview screen
	Then the cases grid with the correct columns is displayed

Scenario: Cases overview: cases sorted by creation time
	Given I am logged in as teacher
	When I go to the Cases overview screen
	Then cases are sorted by creation time

