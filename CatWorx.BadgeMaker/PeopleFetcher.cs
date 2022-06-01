using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json.Linq;

namespace CatWorx.BadgeMaker {
  class PeopleFetcher
  {
    // method to get data from API

    public static List<Employee> GetFromApi() {
      List<Employee> employees = new List<Employee>();
      using (WebClient client = new WebClient())
      {
        // Download information from the URL as a string
        string response = client.DownloadString("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");
        // parse the JSON
        JObject json = JObject.Parse(response);
        // Loop through each token in api response results
        foreach(JToken person in json.SelectToken("results")) {
          Employee employee = new Employee
            (
              person.SelectToken("name.first").ToString(),
              person.SelectToken("name.last").ToString(),
              Int32.Parse(person.SelectToken("id.value").ToString().Replace("-", "")),
              person.SelectToken("picture.large").ToString()
            );
            employees.Add(employee);
          }
        }
        return employees;
        }
    // Method to get employee data from the user
    public static List<Employee> GetEmployees() {
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
  }
}