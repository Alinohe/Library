using Library.Data;
using Library.Data.Entities;
using Library.Data.Repositories;

namespace Library.UserComminucation;

public class UserCommunication : IUserCommunication
{

    private readonly IRepository<Book> _booksRepository;
    private readonly IRepository<Employee> _employeesRepository;
    private readonly IRepository<Client> _clientsRepository;
    private readonly IRepository<Librarian> _librarianRepository;

    public UserCommunication(
   IRepository<Book> booksRepository,
   IRepository<Employee> employeesRepository,
   IRepository<Client> clientsRepository,
   IRepository<Librarian> librarianRepository)
    {
        _booksRepository = booksRepository;
        _employeesRepository = employeesRepository;
        _clientsRepository = clientsRepository;
        _librarianRepository = librarianRepository;
    }



    public void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("Wybierz Z menu" +
            "(1) Display Books menu" +
            "(2) Display Employees" +
            "(3) Display Clients" +
            "(4) Display Librarians" +
            "(q) Exit");
    }

    private object GetInputWrite(string v)
    {
        Console.Write(v);
        return Console.ReadLine();

    }

    private void EmployeeMenu()
    {
        Console.Clear();
        Console.WriteLine("Wybierz Z menu" +
            "(1) Display Employees" +
            "(2) Add Employee" +
            "(3) Remove Employee" +
            "(4) Update Employee" +
            "(5) Back to main menu");
    }

    private void LibrarianMenu()
    {
        Console.Clear();
        Console.WriteLine("Wybierz Z menu" +
            "(1) Display Librarians" +
            "(2) Add Librarian" +
            "(3) Remove Librarian" +
            "(4) Update Librarian" +
            "(5) Back to main menu");
    }

    private void ClientMenu()
    {
        Console.Clear();
        Console.WriteLine("Wybierz Z menu" +
            "(1) Display Clients" +
            "(2) Add Client" +
            "(3) Remove Client" +
            "(4) Update Client" +
            "(5) Back to main menu");
    }

    private void BooksMenu()
    {
        Console.Clear();
        Console.WriteLine("Wybierz Z menu" +
            "(1) Display Books" +
            "(2) Display Books by Author" +
            "(3) Display Books by Genre" +
            "(4) Add Book" +
            "(5) Remove Book" +
            "(6) Update Book" +
            "(9) Back to main menu");


    }

    public void DisplayBooks()
    {
        Console.Clear();
        Console.WriteLine("Lista Ksiazek:");
        foreach (var book in _booksRepository.GetAll())
        {
            Console.WriteLine(book);
        }
    }

    public void DisplayClients()
    {
        Console.Clear();
        Console.WriteLine("Lista Klientow:");
        foreach (var client in _clientsRepository.GetAll())
        {
            Console.WriteLine(client);
        }

    }

    public void DisplayEmployees()
    {
        Console.Clear();
        Console.WriteLine("Lista Pracownikow:");
        foreach (var employee in _employeesRepository.GetAll())
        {
            Console.WriteLine(employee);
        }
    }

    public void DisplayError(string message)
    {
        Console.Clear();
        Console.WriteLine(message);

    }

    public void DisplayLibrarians()
    {
        Console.Clear();
        Console.WriteLine("Lista Bibliotekarzy:");
        foreach (var librarian in _librarianRepository.GetAll())
        {
            Console.WriteLine(librarian);
        }
    }

    public void DisplayMenu()
    {
        Console.Clear();

    }

    public void DisplayMessage(string message)
    {
        Console.Clear();
        Console.WriteLine(message);

    }

    void BookAdded(Book item)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"[{DateTime.Now.ToString("dd-MM-yyyy: HH:mm:ss")}] {item.Id} {item.Title} {item.Author}: Ksiazka zostala dodanado biblioteki");
        Console.ResetColor();
    }

    //public void ChoiceMenu()
    //{

    //}

    public void DisplayBooksByAuthor()
    {
        Console.Clear();
        Console.WriteLine("Lista Ksiazek wedlug autora:");
        foreach (var book in _booksRepository.GetAll())
        {
            Console.WriteLine(book);
        }
    }

    public void DisplayBooksByGenre()
    {
        Console.Clear();
        Console.WriteLine("Lista Ksiazek wedlug gatunku:");
        foreach (var book in _booksRepository.GetAll())
        {
            Console.WriteLine(book);
        }
    }
}



