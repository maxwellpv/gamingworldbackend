Feature: PostUserProfilesServiceTest 	

As a developer
I want to post a user profile through an API
So that i dont have to manually create one in the database.

    Background: 
	
        Given the endpoint https://localhost:5001/api/v1/profiles is available
    @Profile_Creation
    Scenario: Create Profile

        When a POST Request is sent with this body
          | userId | gamingLevel | isStreamer | 
          | 1      | 1           | false      |  
 
        Then a Response with Status 200 is received
        And a UserProfile resource is included in the response body.
          | id |  userId | gamingLevel | isStreamer | gameExperiences | streamingCategories |streamerSponsors | tournamentExperiences | favoriteGames |
          | 1  |     1   | Newbie      | false      |      Array      |          Array      |      Array      |         Array         |     Array     |