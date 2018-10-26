Feature: Error Message_UserRegistration_ExistingUser
	Error message should appears when I try to create user that already exists in the system

@mytag
Scenario: Create New Existing user
	Given User is at the registration page
	When I enter valid credentials for existing user
	| Firstname | Lastname | Email                | Password    |
	| dfdfdso      | dsfsdf  | testolga77@gmail.com | sdasdasdasdsad |

	And Check all mandatory vields
	And Click registration button
	Then Error message should display

