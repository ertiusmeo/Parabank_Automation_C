# Parabank_Automation_C#
This project is to automate registration and login function for https://parabank.parasoft.com/ website


**Instructions:**
* Install Visual Studio (make sure it support MSTest framework)
* Go to Test Explorer window
* Select the test and run

**List of tests:**

* Login_SuccessfulAccess
Verifying succesfull login with valid credentials
* Login_UnsuccessfulAccess
Verifying unsuccesfull login without credentials
* Register_NoRequiredField
Verifying unsuccesfull registration without one of required fields
* Register_OpenForm
Verifying succesfull registration form opening
* Register_PasswordNotMatching
Verifying unsuccesful registration with password and confirm password not matching
* Register_Successful
Verifying successful registration with valid inputs
* Register_UsernameExists
Verifying unsuccessful registration with username already existing
