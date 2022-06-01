// by wrapping the class in CatWorkx.BadgeMaker namespace, you can access it directly from any class that uses CatWorkx.BadgeMaker
namespace CatWorx.BadgeMaker
{
  class Employee
  {
    private string? FirstName;
    private string? LastName;
    private int Id;
    private string? PhotoUrl;

    // employee constructor
    public Employee(string? firstName, string? lastName, int id, string? photoUrl) {
      FirstName = firstName;
      LastName = lastName;
      Id = id;
      PhotoUrl = photoUrl;
    }

    public string GetName() {
      return FirstName + " " + LastName;
    }

    public int GetId() {
      return Id;
    }

    public string? GetPhotoUrl() {
      return PhotoUrl;
    }

    public string GetCompanyName() {
      return "Cat Worx";
    }
  }
}