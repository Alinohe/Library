using Library.Entities;
using Library.Repositories;
using Library.Data;
using Library.Repositories.Repositories;
using Microsoft.VisualBasic;
using System.Security.Cryptography.X509Certificates;



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
    Console.WriteLine($"[{DateTime.Now.ToString("dd-MM-yyyy: HH:mm:ss")}] {item.Id} {item.Title} {item.Author}: Book added");
    Console.ResetColor();
}

void BookRemoved(Books item)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"[{DateTime.Now.ToString("dd-MM-yyyy: HH:mm:ss")}] {item.Id} {item.Title} {item.Author}: Book removed");
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
        stWriter.Write($"[{DateTime.Now.ToString("dd-MM-yyyy: HH:mm:ss")}]-('Id: {e.Id}:') ('Title: {e.Title}:') - ('Author: {e.Author}:') ('Book: {action}') from {sender?.GetType().Name}" + Environment.NewLine);
    }
    Console.WriteLine($"[{DateTime.Now.ToString("dd-MM-yyyy: HH:mm:ss")}]-('Id: {e.Id}:') ('Title: {e.Title}:') - ('Author: {e.Author}:') ('Book: {action}') from {sender?.GetType().Name}");
}

while (true)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Wybierz opcje:(1) wyświetl wszystkie książki; (2) dodaj nową książkę; (3) usuń książkę (q) opuść aplikację");
    Console.ResetColor();
    var input = Console.ReadLine();
    if (input == "q")
    {
        break;
    }
    switch (input)
    {
        case "1":
            Console.WriteLine("Wszystkie książki w bazie danych:");
            Console.WriteLine();
            try
            {
                WriteAllToConsole(booksRepository);
                WriteAllToConsole(bookInFile);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            break;

        case "2":

            Console.Error.WriteLine("Dodaj nową książkę: * oznacza ze informacja jest wymagana");

            try
            {
                AddBooks(booksRepository, bookInFile);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            break;
        case "3":
            Console.WriteLine("Podaj tytul książki do usunięcia");

            try
            {
                RemoveBook(bookInFile);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Niepoprawna opcja");
            Console.ResetColor();
            break;

    }
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}

static void RemoveBook(IRepository<Books> bookInFile)
{
    Console.WriteLine("Podaj tytul ksiazki do usuniecia");
    var input = Console.ReadLine();
    var bookForDelete = bookInFile.GetAll().FirstOrDefault(x => x.Title == input);
    if (bookForDelete != null)
    {
        bookInFile.Remove(bookForDelete);
    }
    else
    {
        throw new Exception($"Ksiazka '{input}' nie istnieje");
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
        //var year = IsNullOrEmpty(input, opt2);
        int? yearInt;
        if (int.TryParse(input, out int result) && result >= 1000 && result <= DateAndTime.Now.Year)
        {
            yearInt = result;
        }
        else if (IsNullOrEmpty(input, opt2) == null)
        {
            yearInt = null;
        }
        else
        {
            throw new Exception("Podany rok jest niepoprawny");
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nPodaj ISBN ksiazki");
        Console.ResetColor();
        input = Console.ReadLine();
        var isbn = IsNullOrEmpty(input, opt2);

        bool isAvailable;
        const string avilable = "ksiazka jest dostepna";
        BookCheck(out input, out isAvailable, avilable);

        bool isNoAvilable;
        const string isBorrowed = "ksiazka nie jest dostepna";
        BookCheck(out input, out isNoAvilable, isBorrowed);

        DateTime? dateOfBorow;
        if (isNoAvilable == true)
        {
            Console.WriteLine("\nPodaj date wypozyczenia ksiazki(dd.mm.rrr)");
            input = Console.ReadLine();
            if (DateTime.TryParse(input, out DateTime result1) && result1 <= DateTime.Now)
            {
                dateOfBorow = result1;
            }
            else if (IsNullOrEmpty(input, opt2) == null)
            {
                dateOfBorow = null;
            }
            else
            {
                throw new Exception("Podana data jest niepoprawna");
            }
        }
        else
        {
            dateOfBorow = null;
        }
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("\nWpisz 'q' zeby zapisac ksiazke do menu albo wcisnij Enter aby zapisac ksiazke i dodac kolejna");
        Console.ResetColor();
        input = Console.ReadLine();


        var books = new[]
        {
            new Books

            {
                Author = author,
                Title = title,
                Genere = genere,
                Year = yearInt,
                ISBN = isbn,
                IsAvailable = isAvailable,
                DateOfBorrow = dateOfBorow,
            }

        };
        bookInFile.AddBatch(books);
        if (input == "q")
        {
            break;
        }
        else
        {
            Console.WriteLine("\nDodaj kolejna ksiazke");
        }
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
        //isAvilable = input == avilable;
        if (input == "+")
        {
            input = "Ksiazka dostepna";
        }
        else if (input == "-" || string.IsNullOrEmpty(input))
        {
            input = "Ksiazka niedostepna";
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
