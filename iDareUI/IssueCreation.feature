@issueCreation
Feature:1261 IssueCreation

	In order to create a new issue in teaching module

	As an DebugUser iDare teacher 

	I want to create issues in teaching module



Background: 

    Given I navigate successfully to the teaching module

    And I am logged in as teacher user

    And I am in the issue list in teaching module

    And I click add issue button



Scenario Outline: 1261 Teacher does not enter required field when creating a new issue

    Given Issue Dialog is open

    When I enter <title> as Title

        And I enter <category> as Category

        And I enter <system> as System

    Then the save button must be disabled


    Examples:   

    | title                   | category | system      |

    | 'Automated Reagent storage error' | 'HW'     | ''          |

    | 'Automated Reagent storage error' | ''       | 'cobas 6800/8800' |

    | ''                      | 'HW'     | 'cobas 6800/8800' |

    | ''                      | ''       | ''          |






Scenario: 1261 Save issue button is enabled when user enter all required fields

    Given Issue Dialog is open

    When I enter 'cobas 6800/8800' as System

        And I enter 'HW' as Category

        And I enter 'Automated Reagent storage error' as Title

    Then the save button must be enabled



Scenario: 1261 User cancel the issue creation

    Given Issue Dialog is open

    When I enter 'HW' as Category

    Then I cancel the issue creation and no new issue is created in the list



Scenario: 1261 New issue Reagent storage error is created successfully

    Given Issue Dialog is open

        And I enter the following fields

        | field    | value                   |

        | System   | cobas 6800/8800       |

        | Category | HW                    |

        | Title    | Automated Reagent storage error | 

        | Description              | Reagent storage error      |

        | ObservedInInstrument     | Observed in instrument     |

        | ExcludedSoftwareVersions | Excluded software versions |

    When I click save button is enabled

    Then the issue list is updated successfully and includes the new created issue

        | field      | value                 |

        | RuleInWork | false                 | 

        | System     | cobas 6800/8800       | 

        | Category   | HW                    |

        | Title      | Automated Reagent storage error | 

        | Footprints               | 0                          |

        | ModifiedBy               | DebugUser                  |

        | Modified                 |                            |

        And the first issue edit button must be the last cell with the defined icon