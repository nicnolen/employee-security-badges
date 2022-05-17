/* HANDLES OUTPUT RELATED LOGIC */
// Import packages
using System;
using System.Collections.Generic;

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
  }
}