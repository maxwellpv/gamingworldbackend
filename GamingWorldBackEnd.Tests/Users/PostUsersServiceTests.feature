Feature: PostUsersServiceTest 	

As a developer
I want to create a new user through an API
So that i dont have to manually create one in the database.

Background: 
	
Given the endpoint http://localhost:5000/api/v1/users is available
@User_Creation
Scenario: Create User

When a POST Request is sent
| username      | email                 | password          | premium |
| Firechocolate | ricardito12@gmail.com | patatacaliente123 | false   |
 
Then a Response With Status 200 is received
And a User Resource is included in the response body.
| id | username      | email                 | password          | premium |
| 1  | Firechocolate | ricardito12@gmail.com | patatacaliente123 | false   |