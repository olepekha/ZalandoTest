Feature: Error message should appears when I try to create new user that already exist in the system
	User try to create existing user and get error message

@mytag
Scenario: Create New Existing user
	Given I AM at home page
	And I navigate to register new user page
	When I enter valid credentials for already existing user
	Then I get error message and do not login 
	
