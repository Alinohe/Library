﻿using Library.Entities;
using Library.Repositories;
using Library.Data;

namespace Library.UserComminucation;

public class UserCommunication : IUserCommunication
{

    private readonly IRepository<Books> _booksRepository;
    private readonly IRepository<Employee> _employeesRepository;
    private readonly IRepository<Client> _clientsRepository;
    private readonly IRepository<Librarian> _librarianRepository;

    public UserCommunication(
   IRepository<Books> booksRepository,
   IRepository<Employee> employeesRepository,
   IRepository<Client> clientsRepository,
   IRepository<Librarian> librarianRepository)
    {
        _booksRepository = booksRepository;
        _employeesRepository = employeesRepository;
        _clientsRepository = clientsRepository;
        _librarianRepository = librarianRepository;
    }

    public void Run()
    {
        Console.WriteLine("Witamy w aplikacji biblioteki!");
        ChoiceMenu();
    }
    public void ChoiceMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Witamy w zbiorze ksiazek." +
            "Wybierz Z menu" +

            "(1) Books menu" +
            "(2) Client menu" +
            "(3) Librarian menu" +
            "(4) Employee menu" +
            "(q) Wyjscie z aplikacji");
        Console.ResetColor();
        var choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                BooksMenu();
                break;
            case "2":
                ClientMenu();
                break;
            case "3":
                LibrarianMenu();
                break;
            case "4":
                EmployeeMenu();
                break;
            case "q":
                Environment.Exit(0);
                break;
            default:
                DisplayError("Niepoprawny wybor");
                break;
        }
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
            "(2) Add Book" +
            "(3) Remove Book" +
            "(4) Update Book" +
            "(5) Back to main menu");


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

    void BookAdded(Books item)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"[{DateTime.Now.ToString("dd-MM-yyyy: HH:mm:ss")}] {item.Id} {item.Title} {item.Author}: Ksiazka zostala dodanado biblioteki");
        Console.ResetColor();
    }


}



