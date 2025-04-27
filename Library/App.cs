using Library.Components.CsvReader;
using System.Xml.Linq;
using Library.Data.Entities;
using Library.Data.Repositories;
using System.Xml.Serialization;
namespace Library;

public class App : IApp
{

    private readonly ICsvReader _csvReader;
    public App(ICsvReader csvReader)
    {
        _csvReader = csvReader;
    }
    public void Run()
    {
        CreateXml();
        QueryXml();
    }

    private void CreateXml()
    {
        var records = _csvReader.ProcessBooks("books.csv");
        var document = new XDocument();
        var books = new XElement("Books", records
            .Select(b =>
            new XElement("Book",
            new XAttribute("Title", b.Title),
            new XAttribute("Author", b.Author),
           new XAttribute("Genere", b.Genere),
              new XAttribute("Volume", b.Volume),
           new XAttribute("Publisher", b.Publisher),
           new XAttribute("Year", b.Year))));

        document.Add(books);
        document.Save("books.xml");
    }

    private void QueryXml()
    {
        var document = XDocument.Load("books.xml");
        var books = document.Descendants("Book")
            .Select(b => new 
            {
                Title = b.Attribute("Title")?.Value,
                Author = b.Attribute("Author")?.Value,
                Genere = b.Attribute("Genere")?.Value,
                Volume = b.Attribute("Volume")?.Value,
                Publisher = b.Attribute("Publisher")?.Value,
                Year = int.TryParse(b.Attribute("Year")?.Value, out var year) ? year : (int?)null
            }).ToList();
        foreach (var book in books)
        {
            Console.WriteLine($"Title: {book.Title} by Author: {book.Author}, Genre: {book.Genere}, Volume: {book.Volume} Publisher: {book.Publisher}, Year: {book.Year}");
        }
    }

}



    //private readonly IRepository<Book> _booksRepository;
    //private readonly IRepository<Employee> _employeesRepository;
    //private readonly IRepository<Client> _clientsRepository;
    //private readonly IRepository<Librarian> _librarianRepository;

    //public App(
    //IRepository<Book> booksRepository,
    //IRepository<Employee> employeesRepository,
    //IRepository<Client> clientsRepository,
    //IRepository<Librarian> librarianRepository)
    //{
    //    _booksRepository = booksRepository;
    //    _employeesRepository = employeesRepository;
    //    _clientsRepository = clientsRepository;
    //    _librarianRepository = librarianRepository;
    //}

    //public void Run()
    //{
    //    Console.WriteLine("Welcome to the Library App!");

    //    //Employees
    //    var employee = new[]
    //  {
    //        new Employee { Name = "Adam" },
    //        new Employee { Name = "Piotr" },
    //        new Employee { Name = "Zuzanna" },
    //    };

    //    foreach (var emp in employee)
    //    {
    //        _employeesRepository.Add(emp);
    //    }
    //    Console.WriteLine();
    //    Console.WriteLine("Employees sorted by Name:");
    //    //foreach (var emp in _employeesRepository.GetAll())
    //    //{
    //    //    Console.WriteLine(emp);
    //    //}
    //    _employeesRepository.Save();
    //    //reading

    //    var items = _employeesRepository.GetAll();
    //    foreach (var item in items)
    //    {
    //        Console.WriteLine(item);
    //    }

    //    //Clients
    //    var clients = new[]

    //    {
    //        new Client { Name = "Kamil" },
    //        new Client { Name = "Kasia" },
    //        new Client { Name = "Marek" },
    //    };
    //    foreach (var client in clients)
    //    {
    //        _clientsRepository.Add(client);
    //    }
    //    Console.WriteLine();
    //    Console.WriteLine("Clients sorted by Name:");
    //    //foreach (var client in _clientsRepository.GetAll())
    //    //{
    //    //    Console.WriteLine(client);
    //    //}
    //    _clientsRepository.Save();
    //    //reading
    //    var items2 = _clientsRepository.GetAll();
    //    foreach (var item2 in items2)
    //    {
    //        Console.WriteLine(item2);
    //    }

    //    //Librarian
    //    var librarian = new[]
    //    {
    //        new Librarian { Name = "Robert" },
    //        new Librarian { Name = "Jarek" },
    //    };
    //    foreach (var lib in librarian)
    //    {
    //        _librarianRepository.Add(lib);
    //    }
    //    Console.WriteLine();
    //    Console.WriteLine("Librarians sorted by Name:");
    //    _librarianRepository.Save();
    //    //reading
    //    var items3 = _librarianRepository.GetAll();
    //    foreach (var item3 in items3)
    //    {
    //        Console.WriteLine(item3);
    //    }

    //    //Books
    //    var books = GenerateSampleBooks();
    //    foreach (var book in books)
    //    {
    //        _booksRepository.Add(book);
    //    }

    //    Console.WriteLine();
    //    Console.WriteLine("Books sorted by Title:");
    //    foreach (var book in _booksRepository.GetAll())
    //    {
    //        Console.WriteLine(book);
    //    }

    //    Console.WriteLine();
    //    Console.WriteLine("Books sorted by Author:");
    //    foreach (var book in _booksRepository.GetAll())
    //    {
    //        Console.WriteLine(book);
    //    }

    //    Console.WriteLine();
    //    Console.WriteLine("Books sorted by buy price:");
    //    foreach (var book in _booksRepository.GetAll())
    //    {
    //        Console.WriteLine(book);
    //    }
    //    Console.WriteLine();
    //    Console.WriteLine("Books sorted by sell price:");
    //    foreach (var book in _booksRepository.GetAll())
    //    {
    //        Console.WriteLine(book);
    //    }


    //}




    //public static List<Book> GenerateSampleBooks()
    //{
    //    return new List<Book>()
    //    {
    //        new Book { Title = "The Lord of the Rings", Author = "J.R.R. Tolkien",
    //            Genere = "Fantasy", Publisher = "Allen & Unwin", Year = 1954,
    //            ISBN = "9780544003415", IsAvailable = true, BuyPrice = 25, SellPrice = 45  },
    //        new Book { Title = "The Hobbit", Author = "J.R.R. Tolkien",
    //            Genere = "Fantasy", Publisher = "Allen & Unwin", Year = 1937,
    //            ISBN = "9780547928227", IsAvailable = true, BuyPrice = 28, SellPrice = 48 },
    //        new Book { Title = "Harry Potter and the Philosopher's Stone", Author = "J.K. Rowling",
    //            Genere = "Fantasy", Publisher = "Bloomsbury", Year = 1997,
    //            ISBN = "9780747532743", IsAvailable = true , BuyPrice = 23, SellPrice = 39 },
    //        new Book { Title = "Harry Potter and the Chamber of Secrets", Author = "J.K. Rowling",
    //            Genere = "Fantasy", Publisher = "Bloomsbury", Year = 1998,
    //            ISBN = "9780747538493", IsAvailable = true, BuyPrice = 44, SellPrice = 68  },
    //        new Book { Title = "Harry Potter and the Prisoner of Azkaban", Author = "J.K. Rowling",
    //            Genere = "Fantasy", Publisher = "Bloomsbury", Year = 1999,
    //            ISBN = "9780747546290", IsAvailable = true , BuyPrice = 26, SellPrice = 44 },
    //        new Book { Title = "Harry Potter and the Goblet of Fire", Author = "J.K. Rowling",
    //            Genere = "Fantasy", Publisher = "Bloomsbury", Year = 2000,
    //            ISBN = "9780747546245", IsAvailable = true , BuyPrice = 31, SellPrice = 49 },
    //        new Book { Title = "Harry Potter and the Order of the Phoenix", Author = "J.K. Rowling",
    //            Genere = "Fantasy", Publisher = "Bloomsbury", Year = 2003,
    //            ISBN = "9780747551003", IsAvailable = true , BuyPrice = 27, SellPrice = 51 },
    //        new Book { Title = "Harry Potter and the Half-Blood Prince", Author = "J.K. Rowling",
    //            Genere = "Fantasy", Publisher = "Bloomsbury", Year = 2005,
    //            ISBN = "9780747581082", IsAvailable = true , BuyPrice = 24, SellPrice = 43 },
    //        new Book { Title = "Harry Potter and the Deathly Hallows", Author = "J.K. Rowling",
    //            Genere = "Fantasy", Publisher = "Bloomsbury", Year = 2007,
    //            ISBN = "9780545010221", IsAvailable = true , BuyPrice = 21, SellPrice = 40 },

    //    };
    //}