# Parabank_Automation_C#
This project is to automate registration and login function for https://parabank.parasoft.com/ website


**Instructions:**
* Install Visual Studio (make sure it support MSTest framework)  
if it doesnt include MSTest you can install by:

_Navigate to Tools -> NuGet Package Manager -> Manager NuGet Packages for Solution and search for the following packages in the Browse tab:_

_MSTest.TestAdapter  
MSTest.TestFramework  
Microsoft.NET.Test.Sdk_

* Go to Test Explorer window
* Select the test and run

**List of tests:**

* Login_SuccessfulAccess  
Verifying successful login with valid credentials
* Login_UnsuccessfulAccess  
Verifying unsuccessful login without credentials
* Register_NoRequiredField  
Verifying unsuccessful registration without one of required fields
* Register_OpenForm  
Verifying successful registration form opening
* Register_PasswordNotMatching  
Verifying unsuccesful registration with password and confirm password not matching
* Register_Successful  
Verifying successful registration with valid inputs
* Register_UsernameExists  
Verifying unsuccessful registration with username already existing
