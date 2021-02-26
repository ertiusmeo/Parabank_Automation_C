using System;
using System.IO;
using System.Linq;

namespace DarekTest.Providers
{
    public class Providers
    {
        public static Uri Login = new Uri("https://parabank.parasoft.com/parabank/index.htm");
        public static string startupPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

    }


    public  class RegistrationFields
    {
        public const string FirstName = "First Name:";
        public const string LastName = "Last Name:";
        public const string Address = "Address:";
        public const string City = "City:";
        public const string State = "State:";
        public const string ZipCode = "Zip Code:";
        public const string Phone= "Phone #:";
        public const string SSN = "SSN:";
        public const string Username = "Username:";
        public const string Password = "Password:";
        public const string ConfirmPassword = "Confirm:";

    }

    public class RegistrationErrors
    {
        public const string FirstName = "First name is required.";
        public const string LastName = "Last name is required.";
        public const string Address = "Address is required.";
        public const string City = "City is required.";
        public const string State = "State is required.";
        public const string ZipCode = "Zip Code is required.";
        public const string Phone = "Phone #:";
        public const string SSN = "Social Security Number is required.";
        public const string Username = "Username is required.";
        public const string Password = "Password is required.";
        public const string ConfirmPassword = "Password confirmation is required.";

    }

    public class CommonFunctions
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }


}