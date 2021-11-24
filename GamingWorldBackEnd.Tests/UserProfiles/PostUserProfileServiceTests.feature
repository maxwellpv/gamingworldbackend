Feature: PostUserProfilesServiceTest 	

As a developer
I want to post a user profile through an API
So that i dont have to manually create one in the database.

Background: 
	
Given the endpoint http://localhost:5000/api/v1/userprofiles is available
@Profile_Creation
Scenario: Create Profile

When a POST Request is sent with this body
| userId     | gamingLevel | isStreamer  | gameExperiences | streamingCategories |streamerSponsors | tournamentExperiences | favoriteGames |
| 1          | medium      | false       |      Array      |          Array      |      Array      |         Array         |     Array     |  
 
Then a Response with Status 200 is received
And a UserProfile resource is included in the response body.
| id |  userId    | gamingLevel | isStreamer  | gameExperiences | streamingCategories |streamerSponsors | tournamentExperiences | favoriteGames |
| 1  |     1      | medium      | false       |      Array      |          Array      |      Array      |         Array         |     Array     |