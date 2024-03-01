Feature: 2_As a seller I would like The languages that I speak be displayed on my Profile page 

#Adding and Duplication

Scenario Outline: 1- Add new Languages on Profile

Given I navigate to Language
When I add '<LanguageKnown>' my level '<MyLevel>' in profile
Then The new '<LanguageKnown>' should display

Examples: 

| LanguageKnown | MyLevel        |

| English       | Fluent         |
| Spanish       | Conversational |
|  English      |  Basic       |


#Updating

Scenario Outline: 2- Update/ Edit the existing language

Given I navigate to Language 
When I edit the second '<LanguageKnown>' with new '<MyLevel>'
Then The '<LanguageKnown>' should be updated

Examples: 
| LanguageKnown | MyLevel  |
|German           | Conversational |


#Deleting

Scenario: 3- Delete an existing Language

Given I navigate to Language
When I delete an existing '<LanguageKnown>'
Then the existing '<LanguageKnown>' should be deleted

Examples: 
| LanguageKnown |

| German       |
|  English     |





