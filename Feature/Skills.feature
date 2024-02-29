Feature: 3_As a Seller I want the add / edit / delete  skill details.


#Adding and Duplication
Scenario: 1-Add skill on profile page

Given I logged in and click Skill tab
When I add '<SkillKnown>' mylevel '<SkillLevel>'
Then The '<SkillKnown>'  should display


Examples: 

| SkillKnown | SkillLevel  |
|Java       | Beginner  |
| Cucumber   | Intermediate |
|  Java      | Intermediate|



#@Update
Scenario: 2-Edit skill that added

Given I logged in and click Skill tab
When I edit last data into '<SkillKnown>' level '<SkillLevel>'
Then The '<SkillKnown>' should edited successfully

Examples: 

| SkillKnown | SkillLevel |
| POM        | Beginner   |


#Delete
Scenario: 3-Delete sill that added

Given I logged in and click Skill tab
When I delete '<SkillKnown>'
Then The '<SkillKnown>' deleted successfully 

Examples: 

| SkillKnown |
| POM        |
| Java           |


