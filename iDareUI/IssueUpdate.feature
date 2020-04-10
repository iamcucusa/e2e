@issueUpdate

Feature: 1262 IssueUpdate

	   In order to update an existing issue in teaching module

        As an DebugUser iDare teacher 
        
        I want to update issues in teaching module

	
Background: 

    Given I navigate successfully to the teaching module

    And I am logged in as teacher user

    And Issue list is displayed

    And The issue list has at least one issue


@ingnored
Scenario Outline: 1262 Teacher does not enter required field when updating first issue in the list

    Given I click in the edit button for the first issue in the list
    
    When I enter <title> as Title

        And I enter <category> as Category

        And I enter <system> as System

    Then the edit issue save button must be disabled


    Examples:   

    | title                                     | category | system            |

    | 'Updated Automated Reagent storage error' | 'HW'     | ''                |

    | 'Updated Automated Reagent storage error' | ''       | 'cobas 6800/8800' |

    | ''                                        | 'HW'     | 'cobas 6800/8800' |

    | ''                                        | ''       | ''                |




Scenario: 1262 Save issue button is enabled when user enter all required fields

    Given I click in the edit button for the first issue in the list

    When I enter 'cobas 6800/8800' as System

        And I enter 'CAT' as Category

        And I enter 'Updated Reagent storage error' as Title

    Then the edit save button must be enabled



Scenario: 1262 User cancel the update of the first issue in the list

    Given I click in the edit button for the first issue in the list

    When I enter 'CAT' as Category

    Then I cancel the first issue update and the issue remaings unchanged


Scenario: 1262 Issue Reagent storage error is updated successfully

    Given I click in the edit button for the first issue in the list

     When I enter 'EDIT9' as Category

        And I click edit save button is enabled

    Then The Category field of the edited issue is equal to 'EDIT9'

        And the ModifiedBy field of the edited issue is equal to the logged username

 


Scenario: 1262 Issue Reagent storage error modified time is updated successfully

    Given I click in the edit button for the first issue in the list

     When I enter 'MyCat' as Category

    Then The Modified field of the edited issue is equal to '' when I save
