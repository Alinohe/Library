namespace Library.Data.Entities;

public class Employee : EntityBase
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public Employee()
    {

    }
    public Employee(string name)
    {

    }
    public Employee(string name, string surname)
    {

    }
    public override string ToString() => $"ID: {Id}, FirstName: {Name} {Surname}";
}
