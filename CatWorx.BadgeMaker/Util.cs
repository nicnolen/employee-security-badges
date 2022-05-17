/* HANDLES OUTPUT RELATED LOGIC */
// Import packages
using System;
using System.IO; // lets us use the Directory class
using System.Collections.Generic;
using System.Drawing; // lets us use the Image class


namespace CatWorx.BadgeMaker
{
  class Util
  {
    // method to print employees
    public static void PrintEmployees(List<Employee> employees) {
      // loop through all the employees
      for (int i = 0; i < employees.Count; i++) {
         string template = "{0,-10}\t{1,-20}\t{2}";
        // write all the employee names to the console. Each item in employees is now an Employee instance
         Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetName(), employees[i].GetPhotoUrl())); //String.Format takes a string to use as a template and then fills in the placeholders with values
      }
    }

    // method to make a CSV file (comma-seperated values)
    public static void MakeCSV(List<Employee> employees) {
      // check to see if folder exists
      if (!Directory.Exists("data")) {
        // if the data folder doesnt exist, create it
        Directory.CreateDirectory("data");
      }

      // create a new CSV file. Note: StreamWriter writes content to a file
      //! NOTE: using can import a namespace or (in this case) temporarily use a resource depending on the context
      using (StreamWriter file = new StreamWriter("data/employees.csv")) {
        // provide column headings
        file.WriteLine("ID,Name,PhotoUrl");

          // loop through all the employees
        for (int i = 0; i < employees.Count; i++) {
          string template = "{0,-10}\t{1,-20}\t{2}";
          // populate the CSV file with actual employee data
          file.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetName(), employees[i].GetPhotoUrl())); //String.Format takes a string to use as a template and then fills in the placeholders with values
        }
      };
    }

    // method to make badges
    public static void MakeBadges(List<Employee> employees) {
      // layout variables
      int BADGE_WIDTH = 669;
      int BADGE_HEIGHT = 1044;

      int COMPANY_NAME_START_X = 0;
      int COMPANY_NAME_START_Y = 110;
      int COMPANY_NAME_WIDTH = 100;

      int PHOTO_START_X = 184;
      int PHOTO_START_Y = 215;
      int PHOTO_WIDTH = 302;
      int PHOTO_HEIGHT = 302;

      int EMPLOYEE_NAME_START_X = 0;
      int EMPLOYEE_NAME_START_Y = 560;
      int EMPLOYEE_NAME_WIDTH = BADGE_WIDTH;
      int EMPLOYEE_NAME_HEIGHT = 100;

      int EMPLOYEE_ID_START_X = 0;
      int EMPLOYEE_ID_START_Y = 690;
      int EMPLOYEE_ID_WIDTH = BADGE_WIDTH;
      int EMPLOYEE_ID_HEIGHT = 100;
      
      // create image
      Image newImage = Image.FromFile("badge.png");
      newImage.Save("data/employeeBadge.png");
    }
  }
}