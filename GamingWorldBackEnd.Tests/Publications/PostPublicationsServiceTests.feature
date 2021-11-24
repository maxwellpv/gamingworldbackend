Feature: PostPublicationsServiceTest 	
As a developer
I want to create a new publication through an API
So that i dont have to manually create one in the database.

	Background: 
		Given the endpoint http://localhost:5000/api/v1/publications is available
	
	@Publication_Creation
	Scenario: Create Publications
		When a POST Request is sent with body
		| publicationType | title                  | content                                                                       | participantLimit | prizePool | tDate     | tHour |  publicatedAt             | gameId | userId |
		|        1        | Example of Publication | Example of content for a publication test where i reach de minimum characters |        10        |    50     |   null    | null  |  2021-11-06T17:20:14.579Z | null   |   1    |
		Then a Response with Status 200 is received
		And a Publication Resource is included in the response body.
		| id | publicationType | title                  | content                                                                       | participantLimit | prizePool | tDate     | tHour |      publicatedAt         | gameId | userId |
		| 1  |        1        | Example of Publication | Example of content for a publication test where i reach de minimum characters |        10        |    50     |   null    | null  |  2021-11-06T17:20:14.579Z | null   |   1    |