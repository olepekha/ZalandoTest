Feature: SpecFlowFeature1
	As user I whant to log into the application with valid credentials and log out from it to the home page

@mytag
Scenario: TryToLogIn
	Given I am at  "https://www.zalando.nl/dames-home/" home page
	And I click on the Login link
	Then I go to Login pop up window
	When I enter valid credentials: email and password

	| Email                | Password    |
	| testolga78@gmail.com | Test_Olga78 |

	And I click on Login button
	Then I go to  "https://www.zalando.nl/myaccount/" page

Scenario: TryToLogOut
Given I am at  "https://www.zalando.nl/dames-home/" home page
	And I click on the Login link
	Then I go to Login pop up window
	When I enter valid credentials: email and password

	| Email                | Password    |
	| testolga78@gmail.com | Test_Olga78 |

	And I click on Login button
	Then I go to  "https://www.zalando.nl/myaccount/" page
	When I cklick on LogOut link
	Then I log out to a "https://www.zalando.nl/dames-home/" home page
