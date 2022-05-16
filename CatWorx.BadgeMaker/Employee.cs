// by wrapping the class in CatWorkx.BadgeMaker namespace, you can access it directly from any class that uses CatWorkx.BadgeMaker
namespace CatWorx.BadgeMaker
{
  class Employee
  {
    public string? FirstName;
    public string? LastName;
    public int Id;
    public string? PhotoUrl;

    // employee constructor
    public Employee(string firstName, string lastName) {
      FirstName = firstName;
      LastName = lastName;
    }

    public string GetName() {
      return FirstName + " " + LastName;
    }
  }
}