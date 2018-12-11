Feature: LogOut
	User should successfully log in and log out from the application

@mytag
Scenario: Log Out
	Given I am at the "https://www.zalando.nl/dames-home/" 
	When I click on the inloggen link
	And I go to the inloggen pop up window
	When I enter valid email and password for user

	| Email                | Password    |
	| testolga78@gmail.com | Test_Olga78 |

	When I click on Inloggen button 
	And I go to the "https://www.zalando.nl/myaccount/" page
	When I click on the Niet Olga? Uitloggen link at mijn account list
	Then I should loged out to the "https://www.zalando.nl/dames-home/"
