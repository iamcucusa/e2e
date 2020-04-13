Feature: RuleCreation
	In order to create a new footprint in teaching module
	As an DebugUser iDare teacher 
	I want to create footprints in teaching module

Background: 
	Given I navigate successfully to the teaching module
	And I am logged in as teacher user
	And I am in the issue list in teaching module

	
	Scenario: 2052 Create Rule with 2 sequenced events sucessfully
	Given I click in the issue Issue1 from the issue list
		And I click add footprint for Issue1
		And Event Catalog is correct for the system cobas6800/8800
		And I select Case1 from production
		And I add the event 'Analytic System Stage Changed to Running' from the catalog to the sequenced events
		And I add the event 'Analytic Stage Changed to Error' from the catalog to the sequenced events
	When I save the Rule
	Then the rule is correct