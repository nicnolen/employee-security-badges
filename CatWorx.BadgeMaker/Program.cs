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
    static List<Employee> GetEmployees() {
      // Create a new list of employees
      List<Employee> employees = new List<Employee>();

      // Collect user values until the value is an empty string
      while (true) {
        // ask the user for an employee name
        Console.WriteLine("Please enter a name: (Press enter to exit): ");

        // get a name from the console and assign it to a variable
        //! string? sets the variable as a nullable string. ? is a nullable reference type
        string? firstName = Console.ReadLine();

        // Break if the user hits ENTER without typing a name

        if (firstName == "")
        {
          break;
        }

        // add a Console.ReadLine() for each value
        Console.Write("Enter last name: ");
        string? lastName = Console.ReadLine();
        Console.Write("Enter ID: ");
        int id = Int32.Parse(Console.ReadLine());
        Console.Write("Enter Photo URL:");
        string? photoUrl = Console.ReadLine();
        // create a new employee instance
        Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
        // add the currentEmployee
        employees.Add(currentEmployee);
      }

      return employees;
    }

    //* Main method serves as the entry point to the application
    //? static means that the scope of the method is at the class level and can be invoked without creating a new class instance (object). Void means there will be no explicit return type
    static void Main(string[] args) {
      // employee-getting code
      List<Employee> employees = GetEmployees();
      // print employees to CSV file
      Util.MakeCSV(employees);
      // make badges for employees
      Util.MakeBadges(employees);
    }
  }
}



