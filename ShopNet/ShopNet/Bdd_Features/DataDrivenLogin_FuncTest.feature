Feature: LogIn
	User should successfully log in to the application with valid credentials

@mytag
Scenario: Successfull LogIn
	Given I am at the "https://www.zalando.nl/dames-home/" home page
	When I click on the Login link
	Then I go to the Login pop up window
	When I enter valid email and password

	| Email                | Password    |
	| testolga78@gmail.com | Test_Olga78 |

	And I click Login button
	Then I go to the "https://www.zalando.nl/myaccount/" page
	