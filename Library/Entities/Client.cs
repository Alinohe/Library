namespace Library.Entities
{
    public class Client : EntityBase
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }

        public override string ToString() => $"Id: {Id}, Name: {Name}, Surname:{Surname}";
    }
}
