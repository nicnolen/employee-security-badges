// See https://aka.ms/new-console-template for more information
//* using imports a common namespace (naming shortcut). Without this naming shortcut, you would have to write System before every Console you use
//? System contains a collection of commonly used methods, data types and data structures
using System;
//? Contains things like lists and dictionaries
using System.Collections.Generic;

//* Namespace organizes and provides a level of seperation in the code. It is followed by the name of the app
namespace CatWorx.BadgeMaker
{
  class Program
  {
    // Method to get employee data from the user
    static List<string> GetEmployees() {
      // Create a new list of employees
      List<string> employees = new List<string>();

      // Collect user values until the value is an empty string
      while (true) {
        // ask the user for an employee name
        Console.WriteLine("Please enter a name: (ctrl C (Windows) or ⌘C for Mac to exit): ");

        // get a name from the console and assign it to a variable
        //! string? sets the variable as a nullable string. ? is a nullable reference type
        string? input = Console.ReadLine();

        // Break if the user hits ENTER without typing a name
        if (input == null) {
          break;
        }
        // add the input to the employees list
        employees.Add(input);
      }

      return employees;
    }

    // method to print employees
    static void PrintEmployees(List<string> employees) {
      // loop through all the employees
      for (int i = 0; i < employees.Count; i++) {
        // write all the employee names to the console
        Console.WriteLine(employees[i]);
      }
    }

    //* Main method serves as the entry point to the application
    //? static means that the scope of the method is at the class level and can be invoked without creating a new class instance (object). Void means there will be no explicit return type
    static void Main(string[] args) {
      // employee-getting code
      List<string> employees = GetEmployees();
      // employee-printing code
      PrintEmployees(employees);
    }
  }
}



