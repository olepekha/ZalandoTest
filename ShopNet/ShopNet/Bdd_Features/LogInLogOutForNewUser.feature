Feature: Log in and Log out for new user
	User shuold be able to create new user with valid credentials, log in on web and log out 

@mytag
Scenario: Create New User and Log in to the "site"
	Given I am on the site home page "https://www.zalando.nl"
		When I click on "Inloggen" link on the home page
		And I lick on "Registreer dan nu" button on the "inloggen" poup windows 
		And I wait until register page is open
		And I enter "olga" into "voornam" field on the "Ik ben een nieuwe klant" page
		And I enter "dddddd" into "achternam" field on the "Ik ben een nieuwe klant" page
		And I enter "testolga78@gmail.com" into "E-mail adress" field on the "Ik ben een nieuwe klant" page
		And I enter "Test_Olga78" into "password" field on the "Ik ben een nieuwe klant" page
		And I click on "Vrouw" checkbox on the "Ik ben een nieuwe klant" page
		And I click on "Ja, hou me per e-mail op de hoogte van de laatste trends en speciale aanbiedingen. (niet verplicht)" check box
		And I click on "Ja, ik ga akkoord met de " checkbox
		And I click on "REGISTREREN" button on "Ik ben een nieuwe klant" page
 Then I loged in to the " https://www.zalando.nl/myaccount/ " page


 Scenario: Log out from "My Account" page 
	Given I am on the site "my account" page
		When I click on "Mijn Zalando" link on the "myaccount" page
		And I click on "Niet Olga? Uitloggen" link on the "mijn account" list
 Then I loged out to the " https://www.zalando.nl/dames-home/ " page