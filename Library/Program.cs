
using Library.Entities;
using Library.Repositories;
using Library.Data;
using Microsoft.Extensions.DependencyInjection;
using Library;

var services = new ServiceCollection();
services.AddSingleton<Books>();
services.AddSingleton<IRepository<Books>, WriteInFileRepository<Books>>();
services.AddSingleton<IRepository<Books>, SqlRepository<Books>>();
services. AddSingleton<IRepository<Books>, ListRepository<Books>>();
services.AddSingleton<IRepository<Client>, WriteInFileRepository<Client>>();
services.AddSingleton<IRepository<Client>, SqlRepository<Client>>();
services.AddSingleton<IRepository<Client>, ListRepository<Client>>();
services.AddSingleton<IRepository<Employee>, WriteInFileRepository<Employee>>();
services.AddSingleton<IRepository<Employee>, SqlRepository<Employee>>();
services.AddSingleton<IRepository<Employee>, ListRepository<Employee>>();
services.AddSingleton<IRepository<Librarian>, WriteInFileRepository<Librarian>>();
services.AddSingleton<IRepository<Librarian>, SqlRepository<Librarian>>();
services.AddSingleton<IRepository<Librarian>, ListRepository<Librarian>>();

services.AddSingleton<IBooksData, BooksData>();
services.AddSingleton<IApp, App>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();
app.Run();






//Console.ForegroundColor = ConsoleColor.DarkCyan;
//Console.WriteLine("Witamy w naszej bibliotece");
//Console.WriteLine("=============================");
//Console.ResetColor();

//string LFile = "Library File.txt";

//var booksRepository = new SqlRepository<Books>(new LibraryDbContext(), BookAdded);
//booksRepository.ItemAdded += BookItemAdded;

//var bookInFile = new WriteInFileRepository<Books>(BookAdded, BookRemoved);
//bookInFile.ItemAdded += BookItemAdded;
//bookInFile.ItemRemoved += BookItemRemoved;

//void BookAdded(Books item)
//{
//    Console.ForegroundColor = ConsoleColor.Blue;
//    Console.WriteLine($"[{DateTime.Now.ToString("dd-MM-yyyy: HH:mm:ss")}] {item.Id} {item.Title} {item.Author}: Ksiazka zostala dodanado biblioteki");
//    Console.ResetColor();
//}

//void BookRemoved(Books item)
//{
//    Console.ForegroundColor = ConsoleColor.Red;
//    Console.WriteLine($"[{DateTime.Now.ToString("dd-MM-yyyy: HH:mm:ss")}] {item.Id} {item.Title} {item.Author}: Ksiazka zostala usunieta z boblioteki");
//    Console.ResetColor();
//}

//void BookItemAdded(object? sender, Books e)
//{
//    WriteToFileAndConsole(sender, e, LFile, "BookAdded");
//}
//void BookItemRemoved(object? sender, Books e)
//{
//    WriteToFileAndConsole(sender, e, LFile, "BookRemoved");
//}

//static void WriteToFileAndConsole(object? sender, Books e, string fileName, string action)
//{
//    using (var stWriter = new StreamWriter(fileName, true))
//    {
//        stWriter.Write($"[{DateTime.Now.ToString("dd-MM-yyyy: HH:mm:ss")}]-('Id: {e.Id}:') ('Title: {e.Title}:') - ('Author: {e.Author}:') ('Book: {action}') from {sender?.GetType().Name}" + Environment.NewLine);
//    }
//    Console.WriteLine($"[{DateTime.Now.ToString("dd-MM-yyyy: HH:mm:ss")}]-('Id: {e.Id}:') ('Title: {e.Title}:') - ('Author: {e.Author}:') ('Book: {action}') from {sender?.GetType().Name}");
//}

//while (true)
//{
//    Console.ForegroundColor = ConsoleColor.DarkBlue;
//    Console.WriteLine("Wybierz opcje:(1) wyświetl wszystkie książki; (2) dodaj nową książkę; (3) usuń książkę; (4) edytuj ksiazke; (q) opuść aplikację");
//    Console.ResetColor();
//    var input = Console.ReadLine();
//    if (input == "q")
//    {
//        break;
//    }
//    switch (input)
//    {
//        case "1":
//            Console.ForegroundColor = ConsoleColor.Blue;
//            Console.WriteLine("Wszystkie książki w bazie danych:");
//            Console.ResetColor();
//            Console.WriteLine();
//            try
//            {
//                WriteAllToConsole(booksRepository);
//                WriteAllToConsole(bookInFile);
//            }
//            catch (Exception ex)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine(ex.Message);
//                Console.ResetColor();
//            }
//            break;

//        case "2":
//            Console.ForegroundColor = ConsoleColor.Blue;
//            Console.Error.WriteLine("Dodaj nową książkę: * oznacza ze informacja jest wymagana");
//            Console.ResetColor();

//            try
//            {
//                AddBooks(booksRepository, bookInFile);
//            }
//            catch (Exception ex)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine(ex.Message);
//                Console.ResetColor();
//            }
//            break;

//        case "3":
//            Console.WriteLine("Podaj tytul książki do usunięcia");

//            try
//            {
//                RemoveBook(bookInFile);
//            }
//            catch (Exception ex)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine(ex.Message);
//                Console.ResetColor();
//            }
//            break;

//        case "4":
//            Console.WriteLine("Podaj tytul ksiazki do aktualizacji");
//            try
//            {
//                UpdateBook(bookInFile);
//            }
//            catch (Exception ex)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine(ex.Message);
//                Console.ResetColor();
//            }
//            break;

//        default:
//            Console.ForegroundColor = ConsoleColor.Red;
//            Console.WriteLine("Niepoprawna opcja");
//            Console.ResetColor();
//            break;

//    }
//}

//static void WriteAllToConsole(IReadRepository<IEntity> repository)
//{
//    var items = repository.GetAll();
//    foreach (var item in items)
//    {
//        Console.WriteLine(item);
//    }
//}

//static void RemoveBook(IRepository<Books> bookInFile)
//{
//    Console.WriteLine("Podaj tytul ksiazki do usuniecia");
//    var input = Console.ReadLine();
//    var bookForDelete = bookInFile.GetAll().FirstOrDefault(x => x.Title == input);
//    if (bookForDelete != null)
//    {
//        bookInFile.Remove(bookForDelete);
//    }
//    else
//    {
//        throw new Exception($"Ksiazka '{input}' nie istnieje");
//    }
//}

//static void UpdateBook(IRepository<Books> bookInFile)
//{
//    Console.ForegroundColor = ConsoleColor.Yellow;
//    Console.WriteLine("Podaj tytul ksiazki do aktualizacji");
//    Console.ResetColor();
//    var Title = Console.ReadLine();

//    Console.ForegroundColor = ConsoleColor.Yellow;
//    Console.WriteLine("Podaj autora * pole moze zostac puste");
//    Console.ForegroundColor = ConsoleColor.Yellow;
//    var Author = Console.ReadLine();

//    Console.ForegroundColor = ConsoleColor.Yellow;
//    Console.WriteLine("Podaj Genere * pole moze zostac puste");
//    Console.ResetColor();
//    var Genere = Console.ReadLine();

//    Console.ForegroundColor = ConsoleColor.Yellow;
//    Console.WriteLine("Podaj Rok wydania * pole moze zostac puste");
//    Console.ResetColor();
//    var Year = Console.ReadLine();

//    Console.ForegroundColor = ConsoleColor.Yellow;
//    Console.WriteLine("Podaj ISBN * pole moze zostac puste");
//    Console.ResetColor();
//    var ISBN = Console.ReadLine();

//    Console.ForegroundColor = ConsoleColor.Yellow;
//    Console.WriteLine("Podaj dostepnosc * pole moze zostac puste");
//    Console.ResetColor();
//    var IsAvailable = Console.ReadLine();
//    var bookForUpdate = bookInFile.GetAll().FirstOrDefault(x => x.Title == Title);

//    while (true)
//    {
//        var opt = "Wartosc Opcjonalna";

//        Console.ForegroundColor = ConsoleColor.Yellow;
//        Console.WriteLine("\nPodaj nowego autora ksiazki");
//        Console.ResetColor();
//        var input = Console.ReadLine();
//        var author = IsNullOrEmpty(input, opt);

//        Console.ForegroundColor = ConsoleColor.Yellow;
//        Console.WriteLine("\nPodaj nowy tytul ksiazki");
//        Console.ResetColor();
//        input = Console.ReadLine();
//        var title = IsNullOrEmpty(input, opt);

//        Console.ForegroundColor = ConsoleColor.Yellow;
//        Console.WriteLine("\nPodaj nowy gatunek ksiazki");
//        Console.ResetColor();
//        input = Console.ReadLine();
//        var genere = IsNullOrEmpty(input, opt);

//        Console.ForegroundColor = ConsoleColor.Yellow;
//        Console.WriteLine("\nPodaj nowy rok wydania ksiazki");
//        Console.ResetColor();
//        input = Console.ReadLine();
//        int? yearInt;

//        if (int.TryParse(input, out int result) && result >= 1000 && result <= DateAndTime.Now.Year)
//        {
//            yearInt = result;
//        }
//        else if (IsNullOrEmpty(input, opt) == null)
//        {
//            yearInt = null;
//        }
//        else
//        {
//            throw new Exception("Podany rok jest niepoprawny");
//        }

//        Console.ForegroundColor = ConsoleColor.Yellow;
//        Console.WriteLine("\nPodaj nowy ISBN ksiazki");
//        Console.ResetColor();
//        input = Console.ReadLine();
//        var isbn = IsNullOrEmpty(input, opt);

//        bool isAvailable;
//        const string avilable = "ksiazka jest dostepna";
//        BookCheck(out input, out isAvailable, avilable);

//        DateTime? dateOfBorow;
//        if (isAvailable == false)
//        {
//            Console.WriteLine("\nPodaj date wypozyczenia ksiazki(dd.mm.rrr)");
//            input = Console.ReadLine();
//            if (DateTime.TryParse(input, out DateTime result1) && result1 <= DateTime.Now)
//            {
//                dateOfBorow = result1;
//            }
//            else if (IsNullOrEmpty(input, opt) == null)
//            {
//                dateOfBorow = null;
//            }
//            else
//            {
//                throw new Exception("Podana data jest niepoprawna");
//            }
//        }
//        else
//        {
//            dateOfBorow = null;
//        }
//        Console.ForegroundColor = ConsoleColor.DarkGreen;
//        Console.WriteLine("\nWpisz 'q' zeby zapisac ksiazke do menu albo wcisnij Enter aby zapisac ksiazke i dodac kolejna");
//        Console.ResetColor();
//        input = Console.ReadLine();

//        var books = new[]
//        {
//            new Books
//            {
//                Author = author,
//                Title = title,
//                Genere = genere,
//                Year = yearInt,
//                ISBN = isbn,
//                IsAvailable = isAvailable,
//                DateOfBorrow = dateOfBorow,
//            }
//        };
//        bookInFile.AddBatch(books);

//        if (input == "q")
//        {
//            break;
//        }
//        else
//        {
//            Console.WriteLine("\nDodaj kolejna ksiazke");
//        }
//    }

//    static string IsNullOrEmpty(string input, string opt)
//    {
//        switch (opt)
//        {
//            case "Informacja MUSI zostac wprowadzona":
//                while (string.IsNullOrEmpty(input))
//                {
//                    Console.ForegroundColor = ConsoleColor.Red;
//                    Console.WriteLine(opt);
//                    Console.ResetColor();
//                    return Console.ReadLine();
//                }
//                break;
//            case "Wartosc zerowa, Opcjonalna":
//                if (string.IsNullOrEmpty(input))
//                {
//                    input = null;
//                    Console.ForegroundColor = ConsoleColor.Yellow;
//                    Console.WriteLine(opt);
//                    Console.ResetColor();
//                }
//                break;
//        }
//        return input;
//    }

//    static void BookCheck(out string? input, out bool isAvilable, string avilable)
//    {
//        Console.ForegroundColor = ConsoleColor.Magenta;
//        Console.WriteLine($"\nWpisz '+', jeśli {avilable}, '-' jeśli nie jest, albo zostaw pole puste");
//        Console.ResetColor();
//        input = Console.ReadLine();
//        isAvilable = input == avilable;
//        if (input == "+")
//        {
//            input = "true";
//        }
//        else if (input == "-" || string.IsNullOrEmpty(input))
//        {
//            input = "false";
//        }
//        else
//        {
//            throw new Exception($"Podane dane w '{avilable}' sa niepoprawne");
//        }
//        isAvilable = bool.Parse(input);
//    }
//}
//void AddBooks(IRepository<Books> repository, IRepository<Books> bookInFile)
//{
//    while (true)
//    {
//        var opt1 = "Informacja MUSI zostac wprowadzona";
//        var opt2 = "Wartosc zerowa, Opcjonalna";

//        Console.ForegroundColor = ConsoleColor.Yellow;
//        Console.WriteLine("\nPodaj autora ksiazki");
//        Console.ResetColor();
//        var input = Console.ReadLine();
//        var author = IsNullOrEmpty(input, opt1);

//        Console.ForegroundColor = ConsoleColor.Yellow;
//        Console.WriteLine("\nPodaj tytul ksiazki");
//        Console.ResetColor();
//        input = Console.ReadLine();
//        var title = IsNullOrEmpty(input, opt1);

//        Console.ForegroundColor = ConsoleColor.Yellow;
//        Console.WriteLine("\nPodaj gatunek ksiazki");
//        Console.ResetColor();
//        input = Console.ReadLine();
//        var genere = IsNullOrEmpty(input, opt2);

//        Console.ForegroundColor = ConsoleColor.Yellow;
//        Console.WriteLine("\nPodaj rok wydania ksiazki");
//        Console.ResetColor();
//        input = Console.ReadLine();
//        int? yearInt;

//        if (int.TryParse(input, out int result) && result >= 1000 && result <= DateAndTime.Now.Year)
//        {
//            yearInt = result;
//        }
//        else if (IsNullOrEmpty(input, opt2) == null)
//        {
//            yearInt = null;
//        }
//        else
//        {
//            throw new Exception("Podany rok jest niepoprawny");
//        }

//        Console.ForegroundColor = ConsoleColor.Yellow;
//        Console.WriteLine("\nPodaj ISBN ksiazki");
//        Console.ResetColor();
//        input = Console.ReadLine();
//        var isbn = IsNullOrEmpty(input, opt2);

//        bool isAvailable;
//        const string avilable = "ksiazka jest dostepna";
//        BookCheck(out input, out isAvailable, avilable);

//        DateTime? dateOfBorow;
//        if (isAvailable == false)
//        {
//            Console.WriteLine("\nPodaj date wypozyczenia ksiazki(dd.mm.rrr)");
//            input = Console.ReadLine();
//            if (DateTime.TryParse(input, out DateTime result1) && result1 <= DateTime.Now)
//            {
//                dateOfBorow = result1;
//            }
//            else if (IsNullOrEmpty(input, opt2) == null)
//            {
//                dateOfBorow = null;
//            }
//            else
//            {
//                throw new Exception("Podana data jest niepoprawna");
//            }
//        }
//        else
//        {
//            dateOfBorow = null;
//        }
//        Console.ForegroundColor = ConsoleColor.DarkGreen;
//        Console.WriteLine("\nWpisz 'q' zeby zapisac ksiazke do menu albo wcisnij Enter aby zapisac ksiazke i dodac kolejna");
//        Console.ResetColor();
//        input = Console.ReadLine();

//        var books = new[]
//        {
//            new Books
//            {
//                Author = author,
//                Title = title,
//                Genere = genere,
//                Year = yearInt,
//                ISBN = isbn,
//                IsAvailable = isAvailable,
//                DateOfBorrow = dateOfBorow,
//            }
//        };
//        bookInFile.AddBatch(books);

//        if (input == "q")
//        {
//            break;
//        }
//        else
//        {
//            Console.WriteLine("\nDodaj kolejna ksiazke");
//        }
//    }

//    static string IsNullOrEmpty(string input, string opt)
//    {
//        switch (opt)
//        {
//            case "Informacja MUSI zostac wprowadzona":
//                while (string.IsNullOrEmpty(input))
//                {
//                    Console.ForegroundColor = ConsoleColor.Red;
//                    Console.WriteLine(opt);
//                    Console.ResetColor();
//                    return Console.ReadLine();
//                }
//                break;
//            case "Wartosc zerowa, Opcjonalna":
//                if (string.IsNullOrEmpty(input))
//                {
//                    input = null;
//                    Console.ForegroundColor = ConsoleColor.Yellow;
//                    Console.WriteLine(opt);
//                    Console.ResetColor();
//                }
//                break;
//        }
//        return input;
//    }

//    static void BookCheck(out string? input, out bool isAvilable, string avilable)
//    {
//        Console.ForegroundColor = ConsoleColor.Magenta;
//        Console.WriteLine($"\nWpisz '+', jeśli {avilable}, '-' jeśli nie jest, albo zostaw pole puste");
//        Console.ResetColor();
//        input = Console.ReadLine();
//        isAvilable = input == avilable;
//        if (input == "+")
//        {
//            input = "true";
//        }
//        else if (input == "-" || string.IsNullOrEmpty(input))
//        {
//            input = "false";
//        }
//        else
//        {
//            throw new Exception($"Podane dane w '{avilable}' sa niepoprawne");
//        }
//        isAvilable = bool.Parse(input);
//    }
//}
