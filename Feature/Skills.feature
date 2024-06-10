Feature: This test suite runs my profile skill related test scenarios

Scenario Outline: 1. Verify user is able to add known skills with experience level
	Given User logs into Mars application
	When User clicks on the skill feature
	And The user adds '<skill>' skill with '<experience level>' experience level into the known skills list
	Then The '<skill>' skill with '<experience level>' experience level should appear in the known skills list

	Examples:
    |  skill   | experience level |
    |  Selenium  | Intermediate     |

Scenario Outline: 2. Verify user is able to edit an experience level from the known skill list
	Given User logs into Mars application
	When User clicks on the skill feature
	And The user adds '<skill>' skill with '<experience level>' experience level into the known skills list
	And The user edits the '<skill>' skill with '<new experience level>' experience level from the known skills list
	Then The experience level for '<skill>' skill should be updated to '<new experience level>'

	Examples:
    |   skill  | experience level | new experience level |
    |   Tosca  | Intermediate     | Beginner             |

Scenario Outline: 3. Verify user is able to delete an existing known skill
	Given User logs into Mars application
	When User clicks on the skill feature
	And The user adds '<skill>' skill with '<experience level>' experience level into the known skills list
	And The User deletes the skill '<skill>'
	Then The skill '<skill>' should not be visible on the profile page

	Examples:
    | skill         | experience level |
    | C#     | Intermediate     |

Scenario Outline: 4. Verify user attempting to add a skill already present in the known skill list
	Given User logs into Mars application
	When User clicks on the skill feature
	And The user adds '<skill>' skill with '<experience level>' experience level into the known skills list
	And The user adds skill '<skill>' with '<experience level>' experience level that is already displayed in their known skills list
	Then The skill '<skill>' should not be duplicated in the known skills list

	Examples:
    | skill             | experience level |
    | Java   | Intermediate     |

Scenario Outline: 5. Verify user tries to add a skill with the same name but different cases
	Given User logs into Mars application
	When User clicks on the skill feature
	And The user adds '<skill>' skill with '<experience level>' experience level into the known skills list
	And The user adds '<new skill>' skill with '<experience level>' experience level with the same name but different cases
	Then The system should accept the same skill '<skill>' with '<experience level>' experience level with different case

	Examples:
    | skill  | experience level | new skill |
    | Specflow | Intermediate     | SPECFLOW    |

Scenario Outline: 6. Verify that the system rejects saving an empty skill field with the chosen experience level in the skill profile section
	Given User logs into Mars application
	When User clicks on the skill feature
	And The user adds '<skill>' skill with '<experience level>' experience level into the known skills list
	Then The system should reject showcasing an empty '<skill>' field and display an error message

	Examples:
    | skill | experience level |
    |       | Intermediate     |

Scenario Outline: 7. Verify that the user attempts to add a skill field containing only numbers
	Given User logs into Mars application
	When User clicks on the skill feature
	And The user adds '<skill>' skill with '<experience level>' experience level  with the skill field containing only numbers
	Then The '<skill>' skill with '<experience level>' experience level should appear in the known skills list

	Examples:
    | skill  | experience level |
    | 476357 | Intermediate     |

Scenario Outline: 8.  Verify that the user attempts to add a skill field containing special characters
	Given User logs into Mars application
	When User clicks on the skill feature
	And The user adds '<skill>' skill with '<experience level>' experience level with the skill field containing special characters
	Then The '<skill>' skill with '<experience level>' experience level should appear in the known skills list

	Examples:
    | skill    | experience level |
    | $#^*(!@# | Intermediate     |

Scenario Outline: 9. Verify that the system rejects saving an invalid experience level
	Given User logs into Mars application
	When User clicks on the skill feature
	And The user adds '<skill>' skill with '<experience level>' but refrains from selecting any experience level and leaves it at the default
	Then The system should reject showcasing an empty '<experience level>' field and display an error message

	Examples:
    |   skill       | experience level |
    |   C#      |                  |