using Library.Entities;
using Library.Repositories;
using Library.Data;
using System.Net;
using Library.Repositories.Repositories;
using System.Xml.Linq;




var repository = new SqlRepository<Books>(new LibraryDbContext(), BooksAdded);

//var item2Added = new Action<BusinessPartner>(item => Console.WriteLine($"Business Partner Added => {item.Name}"));
//var businessPartnerRepository = new SqlRepository<BusinessPartner>(new MotoAppDbContext(), item2Added);
static void BooksRepositoryOnItemAdded(object? sender, Books e)
{
    Console.WriteLine($"Book Added => {e.Title}: from {sender?.GetType().Name}");
}

AddEmplpoyees(repository);
WriteAllToConsole(repository);

static void BooksAdded(Books item)
{
    var books = item;

    Console.WriteLine($"{item.Title}: Book added");
}

static void AddEmplpoyees(IRepository<Books> repository)
{
    if (repository is null)
    {
        throw new ArgumentNullException(nameof(repository));
    }

    var books = new[]
    {
        new Books { Title = "1984", Author = "George Orwell" },
        new Books {Title = "Brave New World", Author = "Aldous Huxley"},
        new Books { Title = "The Green Mile", Author = "Stephen King" },
    };
    repository.AddBatch(books);
    "Books Added".AddBatch(books);
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}
