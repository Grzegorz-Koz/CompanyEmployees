using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

namespace CompanyEmployees
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine("\r"); // Just to make output more transparent.
            Console.WriteLine("Welcome to CompanyEmployees!");
            Console.WriteLine("\r"); 
            Console.WriteLine("Please complete the company employee's details:");
            // For practicing use of "\r\n" 
            Console.WriteLine("- Name\r\n- Last name\r\n- Age\r\n- Gender\r\n- PESEL\r\n- Employee number");
            Console.WriteLine("\r");

            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            
            Console.WriteLine("Enter your surname:");
            string surName = Console.ReadLine();

            Console.WriteLine("Enter your age:");
            /* 
             * byte - Because:
             * Humans don't normally live beyond 255 years :)
             * And maybe, someday sorting will be required on this field..
             */
            string inputAge = Console.ReadLine();
            byte age;
            while (!byte.TryParse(inputAge, out age)) {
                Console.WriteLine("You have not entered a number. Please enter you age once again:");
                inputAge = Console.ReadLine();
            }     
            

            Console.WriteLine("Enter your gender (m or f):");
            string inputGender = Console.ReadLine();            
            // In general, gender can be represented by single char. It is why I am using "char gender".                        
            char gender = 'a'; // Could be any letter. Just for protection against using an unassigned variable in Console.WriteLine.
            bool correctValue = false;
            while (!correctValue)
            {
                string errorInfo = ""; // = "" - Protection against using an unassigned variable in Console.WriteLine.                
                if (!(char.TryParse(inputGender, out gender) && Regex.IsMatch(inputGender, @"^[\p{L}]+$")))
                {
                    errorInfo = "Entered value is longer then a single character or it is a number. Try once again:";
                }                
                else if (!String.Equals(inputGender, "m") && !String.Equals(inputGender, "f"))
                {
                    errorInfo = "Entered value is not \"m\" or \"f\". Try once again:";
                } 
                else
                {
                    correctValue = true;
                }
                if (!correctValue)
                {
                    Console.WriteLine($"{errorInfo}");
                    inputGender = Console.ReadLine();
                }                               
            }

            Console.WriteLine("Enter your PESEL:");
            string pesel = Console.ReadLine();
            // Validation if entered value is PESEL
            while (!Regex.IsMatch(pesel, "^[0-9]+$") || pesel.Length != 11)
            {
                Console.WriteLine("It is not PESEL. Try again:");
                pesel = Console.ReadLine();
            }

            Console.WriteLine("Enter the number you would like to have as employee number (10 characters):");
            string inputEmployeeNumber = Console.ReadLine();
            while (!Regex.IsMatch(inputEmployeeNumber, "^[0-9]+$") || inputEmployeeNumber.Length != 10)
            {
                Console.WriteLine("It is not correct number with 10 characters. Try again:");
                inputEmployeeNumber = Console.ReadLine();
            }
            // Should be long as int is not enough. We can have employee number like 9999999999.
            long employeeNumber;
            long.TryParse(inputEmployeeNumber, out employeeNumber);


            Console.WriteLine("\r");            
            Console.WriteLine("The new employee is added to CompanyEmployees:");
            Console.WriteLine($"- Name: {name}");
            Console.WriteLine($"- Surname: {surName}");
            Console.WriteLine($"- Age: {age}");
            if (gender == 'm')
            {
                Console.WriteLine("- Gender: male");
            }
            else 
            { 
                Console.WriteLine("- Gender: female"); 
            }                                    
            Console.WriteLine($"- PESEL: {pesel}");
            Console.WriteLine($"- Employee number: {employeeNumber}");
        }
    }
}