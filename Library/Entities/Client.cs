namespace Library.Entities;

public class Client : EntityBase
{
    public string? Name { get; set; }
    public string? Surname { get; set; }

    public Client()
    {

    }
    public Client(string name)
    {

    }
    public Client(string name, string surname)
    {

    }

    public override string ToString() => $"Id: {Id}, Name: {Name} {Surname}";
}
