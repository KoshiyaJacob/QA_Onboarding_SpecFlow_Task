Feature: This test suite runs my profile language related test scenarios

Scenario Outline: 1. Verify user is able to add known languages with proficiency level
	Given User logs into Mars application
	When User adds '<language>' language with '<proficiency level>' proficiency level into the known languages list
	Then The '<language>' language with '<proficiency level>' proficiency level should appear in the known languages list

	Examples:
    | language | proficiency level |
    | English  | Basic             |

Scenario Outline: 2. Verify user is able to edit a proficiency level from the known language
	Given User logs into Mars application
	When User adds '<language>' language with '<proficiency level>' proficiency level into the known languages list
	And User edits the '<language>' language with '<new proficiency level>' proficiency level from the known languages list
	Then The proficiency level for '<language>' language should be updated to '<new proficiency level>'

	Examples:
    | language | proficiency level |  new proficiency level  |
    | English  | Basic             |  Fluent                 |
    
Scenario Outline: 3. Verify user is able to delete an existing known language
	Given User logs into Mars application
	When User adds '<language>' language with '<proficiency level>' proficiency level into the known languages list
	And The User deletes the language '<language>'
	Then The language '<language>' should not be visible on the profile page

	Examples:
    | language | proficiency level |
    | Spanish  | Conversational    |

Scenario Outline: 4. Verify user attempting to add a language already present in the known languages list
	Given User logs into Mars application
	When User adds '<language>' language with '<proficiency level>' proficiency level into the known languages list
	And The user adds language '<language>' with '<proficiency level>' proficiency level that is already displayed in their known languages list
	Then The language '<language>' should not be duplicated in the known languages list

	Examples:
    | language | proficiency level |
    |   | Conversational    |

Scenario Outline: 5. Verify that the system rejects saving an empty language field with the chosen proficiency level in the language profile section
	Given User logs into Mars application
	When User adds '<language>' language with '<proficiency level>' proficiency level into the known languages list
	Then The system should reject showcasing an empty '<language>' and display an error message
	
	Examples:
    | language | proficiency level |
    |          | Conversational    |

Scenario Outline: 6. Verify user tries to add a language with the same name but different cases
	Given User logs into Mars application
	When User adds '<language>' language with '<proficiency level>' proficiency level into the known languages list
	And The user adds '<new language>' language with '<proficiency level>' proficiency level with the same name but different cases
	Then The system should accept the same language '<language>' with '<proficiency level>' proficiency level with different case

	Examples:
    | language | proficiency level | new language |
    | German   | Basic             | GErMAN       |

Scenario Outline: 7. Verify that the user attempts to add a language field containing only numbers
	Given User logs into Mars application
	When The user adds '<language>' language with '<proficiency level>' proficiency level with language field containing only numbers
	Then The '<language>' language with '<proficiency level>' proficiency level should appear in the known languages list

	Examples:
    | language | proficiency level |
    | 35642    | Basic             |

Scenario Outline: 8. Verify that the user attempts to add a language field containing special characters
	Given User logs into Mars application
	When The user adds '<language>' language with '<proficiency level>' proficiency level with the language field containing special characters
	Then The '<language>' language with '<proficiency level>' proficiency level should appear in the known languages list

	Examples:
    | language    | proficiency level |
    | %$&(^@+%!   | Basic             |

Scenario Outline: 9. Verify that the system rejects saving an invalid proficiency level
	Given User logs into Mars application
	When The user adds '<language>' language with '<proficiency level>' but refrains from selecting any proficiency level and leaves it at the default
	Then The system should reject showcasing an empty '<proficiency level>' and display an error message

	Examples:
    | language    | proficiency level |
    | Urud        |                   |
