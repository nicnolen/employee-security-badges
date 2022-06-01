/* HANDLES OUTPUT RELATED LOGIC */
// Import packages
using System;
using System.IO; // lets us use the Directory class
using System.Collections.Generic;
using System.Drawing; // lets us use the Image class
using System.Net; // lets us use the WebClient class
using System.Runtime.Serialization;

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

      // graphics objects
      StringFormat format = new StringFormat();
      format.Alignment = StringAlignment.Center;
      int FONT_SIZE = 32;
      Font font = new Font("Arial", FONT_SIZE);
      Font monoFont = new Font("Courier New", FONT_SIZE);

      SolidBrush brush = new SolidBrush(Color.Black);

      // instance of WebClient is disposed after code in the block has run
      using(WebClient client = new WebClient()) {
        // access and iterate through employee information
        for (int i = 0; i < employees.Count; i++) {
          // convert stream to image
          Image photo = Image.FromStream(client.OpenRead(employees[i].GetPhotoUrl()));
          // signify that the badge image will be the background image where you print employee data
          Image background = Image.FromFile("badge.png");
          // create canvas to make the badge
          Image badge = new Bitmap(BADGE_WIDTH, BADGE_HEIGHT);
          // allow graphical modifications of the badge
          Graphics graphic = Graphics.FromImage(badge);
          // draw images on the badge. NOTE Rectangle class lets you allocate a position and size on the badge
          graphic.DrawImage(background, new Rectangle(0, 0, BADGE_WIDTH, BADGE_HEIGHT));
          // insert the employee photo
          graphic.DrawImage(photo, new Rectangle(PHOTO_START_X, PHOTO_START_Y, PHOTO_WIDTH, PHOTO_HEIGHT));
          // company name
          // draw the specified text string in the specified Reactangle
          graphic.DrawString(employees[i].GetCompanyName(), font, new SolidBrush(Color.White), new Rectangle(
            COMPANY_NAME_START_X,
            COMPANY_NAME_START_Y,
            BADGE_WIDTH,
            COMPANY_NAME_WIDTH
          ),
          format
          );
          // employee name
          graphic.DrawString(
            employees[i].GetName(),
            font,
            brush,
            new Rectangle(
              EMPLOYEE_NAME_START_X,
              EMPLOYEE_NAME_START_Y,
              BADGE_WIDTH,
              EMPLOYEE_NAME_HEIGHT
            ),
            format
          );
          // employee ID
          graphic.DrawString(
            employees[i].GetId().ToString(),
            monoFont,
            brush,
            new Rectangle(
              EMPLOYEE_ID_START_X,
              EMPLOYEE_ID_START_Y,
              EMPLOYEE_ID_WIDTH,
              EMPLOYEE_ID_HEIGHT
            ),
            format
          );
          // convert file name into a string
          string template = "data/{0}_badge.png";
          // save the badge
          badge.Save(string.Format(template, employees[i].GetId()));
        }
      }
    }
  }
}