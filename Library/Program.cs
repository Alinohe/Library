using Library.Entities;
using Library.Repositories;
using Library.Data;
using Library.Repositories.Repositories;



Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Welcome to our Library");
Console.WriteLine("=========================");
Console.ResetColor();

string LFile = "Library File.txt";

var booksRepository = new SqlRepository<Books>(new LibraryDbContext(), BookAdded);
booksRepository.ItemAdded += BookItemAdded;

var bookInFile = new WriteInFileRepository<Books>(BookAdded, BookRemoved);
bookInFile.ItemAdded += BookItemAdded;
bookInFile.ItemRemoved += BookItemRemoved;


void BookAdded(Books item)
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine($"[{DateTime.Now.ToString("dd-MM-yyyy: HH:mm:ss")}] {item.Id} {item.Title}: Book added");
    Console.ResetColor();
}

void BookRemoved(Books item)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"[{DateTime.Now.ToString("dd-MM-yyyy: HH:mm:ss")}] {item.Id} {item.Title}: Book removed");
    Console.ResetColor();
}

void BookItemAdded(object? sender, Books e)
{
    WriteToFileAndConsole(sender, e, LFile, "BookAdded");
}
void BookItemRemoved(object? sender, Books e)
{
    WriteToFileAndConsole(sender, e, LFile, "BookRemoved");
 }

static void WriteToFileAndConsole(object? sender, Books e, string fileName, string action)
{
    using (var stWriter = new StreamWriter(fileName, true))
    {
        stWriter.Write($"[{DateTime.Now.ToString("dd-MM-yyyy: HH:mm:ss")}]-('Id: {e.Id}:') ('Title: {e.Title}:') ('Book: {action}') flom {sender?.GetType().Name}" + Environment.NewLine);
    }
    Console.WriteLine($"[{DateTime.Now.ToString("dd-MM-yyyy: HH:mm:ss")}]-('Id: {e.Id}:') ('Title: {e.Title}:') ('Book: {action}') flom {sender?.GetType().Name}");
}
while (true)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Choose an option:(1) wyświetl wszystkie książki; (2) dodaj nową książkę; (3) usuń książkę (q) opuść aplikację");
    Console.ResetColor();
    var input = Console.ReadLine();
    if (input == "1")
    {
<<<<<<< HEAD
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Lista zapisanych ksiazek");
        Console.ResetColor();
        var books = booksRepository.GetAll();
        foreach (var book in books)
        {
            Console.WriteLine($"Id: {book.Id} Title: {book.Title}");
        }
    }
    else if (input == "2")
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Dodaj nową książkę");
        Console.ResetColor();
        Console.WriteLine("Podaj tytuł książki:");
        var title = Console.ReadLine();
        Console.WriteLine("Podaj autora książki:");
        var author = Console.ReadLine();
        var book = new Books { Title = title, Author = author };
        booksRepository.Add(book);
        bookInFile.Add(book);
    }
    else if (input == "3")
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Usuń książkę");
        Console.ResetColor();
        Console.WriteLine("Podaj Id książki do usunięcia:");
        var id = int.Parse(Console.ReadLine());
        var book = booksRepository.GetById(id);
        booksRepository.Remove(book);
        bookInFile.Remove(book);
    }
    else if (input == "q")
    {
        break;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Niepoprawna opcja");
        Console.ResetColor();
    }
=======
        new Books { Title = "1984", Author = "George Orwell" },
        new Books {Title = "Brave New World", Author = "Aldous Huxley"},
        new Books { Title = "The Green Mile", Author = "Stephen King" },
    };
    repository.AddBatch(books);
    "Books Added".AddBatch(books);
>>>>>>> 7e3a901f2244fd43954e2ff7c89282467e6124c2
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}

void AddBooks(IRepository<Books> repository, IRepository<Books> bookInFile)
{
    while (true)
    {
        var opt1 = "Informacja MUSI zostac wprowadzona";
        var opt2 = "Wartosc zerowa, Opcjonalna";

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nPodaj autora ksiazki");
        Console.ResetColor();
        var input = Console.ReadLine();
        var author = IsNullOrEmpty(input, opt1);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nPodaj tytul ksiazki");
        Console.ResetColor();
        input = Console.ReadLine();
        var title = IsNullOrEmpty(input, opt1);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nPodaj gatunek ksiazki");
        Console.ResetColor();
        input = Console.ReadLine();
        var genere = IsNullOrEmpty(input, opt2);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nPodaj rok wydania ksiazki");
        Console.ResetColor();
        input = Console.ReadLine();
        var year = IsNullOrEmpty(input, opt2);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nPodaj ISBN ksiazki");
        Console.ResetColor();
        input = Console.ReadLine();
        var isbn = IsNullOrEmpty(input, opt2);

        bool isAvailable;
        const string avilable = "ksiazka jest dostepna";
        BookCheck(out input, out isAvailable, avilable);

        if (isAvailable == true)
        {
            var book = new Books
            {
                Author = author,
                Title = title,
                Genere = genere,
                Year = int.Parse(year),
                ISBN = isbn,
                IsAvailable = isAvailable
            };
            repository.Add(book);
            bookInFile.Add(book);
        }
        else
        {
            throw new Exception("Ksiazka jest wypozyczona");
        }
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\nWpisz 'q' zeby zapisac ksiazke do menu albo wcisnij Enter aby zapisac ksiazke i dodac kolejna");
        Console.ResetColor();
        input = Console.ReadLine();


    }


    static string IsNullOrEmpty(string input, string opt)
    {
        switch (opt)
        {
            case "Informacja MUSI zostac wprowadzona":
                while (string.IsNullOrEmpty(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(opt);
                    Console.ResetColor();
                    return Console.ReadLine();
                }
                break;
            case "Wartosc zerowa, Opcjonalna":
                if (string.IsNullOrEmpty(input))
                {
                    input = null;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(opt);
                    Console.ResetColor();
                }
                break;

        }
        return input;

    }

    static void BookCheck(out string? input, out bool isAvilable, string avilable)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"\nWpisz '+', jeśli {avilable}, '-' jeśli nie jest, albo zostaw pole puste");
        Console.ResetColor();
        input = Console.ReadLine();
        isAvilable = input == avilable;
        if (input == "+")
        {
            isAvilable = true;
        }
        else if (input == "-")
        {
            isAvilable = false;
        }
        else
        {
            throw new Exception($"Podane dane w '{avilable}' sa niepoprawne");
        }
        isAvilable = bool.Parse(input);
    }

}

//var repository = new SqlRepository<Books>(new LibraryDbContext(), BooksAdded);

////var item2Added = new Action<BusinessPartner>(item => Console.WriteLine($"Business Partner Added => {item.Name}"));
////var businessPartnerRepository = new SqlRepository<BusinessPartner>(new MotoAppDbContext(), item2Added);
//static void BooksRepositoryOnItemAdded(object? sender, Books e)
//{
//    Console.WriteLine($"Book Added => {e.Title}: from {sender?.GetType().Name}");
//}

//AddEmplpoyees(repository);
//WriteAllToConsole(repository);

//static void BooksAdded(Books item)
//{
//    var books = item;

//    Console.WriteLine($"{item.Title}: Book added");
//}

//static void AddEmplpoyees(IRepository<Books> repository)
//{
//    if (repository is null)
//    {
//        throw new ArgumentNullException(nameof(repository));
//    }

//    var books = new[]
//    {
//        new Books { Title = "1984", Author = "George Orwell" },
//        new Books {Title = "Brave New World", Author = "Aldous Huxley"},
//        new Books { Title = "The Green Mile", Author = "Stephen King" },
//    };
//    repository.AddBatch(books);
//    "Books Added".AddBatch(books);
//}

//static void WriteAllToConsole(IReadRepository<IEntity> repository)
//{
//    var items = repository.GetAll();
//    foreach (var item in items)
//    {
//        Console.WriteLine(item);
//    }
//}
