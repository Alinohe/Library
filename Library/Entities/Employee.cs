namespace Library.Entities
{
    public class Employee :EntityBase
    {
        public Employee()
        {

        }
        public Employee(string name)
        {

        }
        public Employee(string name, string surname)
        {

        }
        public string? FirstName { get; set; }
        public string? Surname { get; set; }

        public override string ToString() => $"ID: {Id}, FirstName: {FirstName} Sunrame: {Surname}";
    }
}
