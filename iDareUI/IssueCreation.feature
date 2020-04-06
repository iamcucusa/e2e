Feature: IssueCreation

	In order to create a new issue in teaching module

	As an DebugUser iDare teacher 

	I want to create issues in teaching module



Background: 

    Given I navigate successfully to the teaching module

    And I am in the issue list in teaching module

    And I click add issue button



Scenario Outline: Teacher does not enter required field when creating a new issue

    Given Issue Dialog is open

    When I enter <title> as Title

        And I enter <category> as Category

        And I enter <system> as System

    Then the save button must be disabled



    Examples:   

    | title                   | category | system      |

    | 'Reagent storage error' | 'HW'     | ''          |

    | 'Reagent storage error' | ''       | 'cobas 6800/8800' |

    | ''                      | 'HW'     | 'cobas 6800/8800' |

    | ''                      | ''       | ''          |





Scenario: Save issue button is enabled when user enter all required fields

    Given Issue Dialog is open

    When I enter 'cobas 6800/8800' as System

        And I enter 'HW' as Category

        And I enter 'Reagent storage error' as Title

    Then the save button must be enabled



Scenario: New issue Reagent storage error is created successfully

    Given Issue Dialog is open

        And I enter the following fields

        | field    | value                   |

        | System   | 'cobas 6800/8800'       |

        | Category | 'HW'                    |

        | Title    | 'Reagent storage error' | 

        | Description              | 'Reagent storage error'      |

        | ObservedInInstrument     | 'Observed in instrument'     |

        | ExcludedSoftwareVersions | 'Excluded software versions' |

    When I click save button is enabled

    Then the issue list is updated successfully and includes the new created issue

        And the the fiedls have the correct value

        | field    | value                   |

        | System   | 'cobas 6800/8800'       |

        | Category | 'HW'                    |

        | Title    | 'Reagent storage error' | 

        | Description              | 'Reagent storage error'      |

        | ObservedInInstrument     | 'Observed in instrument'     |

        | ExcludedSoftwareVersions | 'Excluded software versions' |

        | Footprints               | 0                            |

        | ModifiedBy               | 'DebugUser'                  |

        And the first issue edit button must be the last cell with the defined icon