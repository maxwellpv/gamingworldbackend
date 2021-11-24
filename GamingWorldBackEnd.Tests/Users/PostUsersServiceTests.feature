Feature: PostUsersServiceTest 	

As a developer
I want to create a new user through an API
So that i dont have to manually create one in the database.

    Background: 
	
        Given the endpoint https://localhost:5001/api/v1/users/auth/sign-up is available
    @User_Creation
    Scenario: Create User

        When a POST Request is sent
          | username       | email                  | password          | firstName | lastName |
          | Firechocolate2 | ricardito122@gmail.com | patatacaliente123 | ricardo   | patata   |
 
        Then a Response With Status 200 is received
        And a User Resource is included in the response body.
          | message                  |
          | Registration successful. |