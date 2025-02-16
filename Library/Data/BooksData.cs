using Library.Entities;
using Library.Repositories;
namespace Library.Data;

public class BooksData : IBooksData
{
    private readonly IRepository<Books> _bookStore;
    public BooksData(IRepository<Books> bStore)
    {
        _bookStore = bStore;
    }

    public List<Books> GetByTitle()
    {
        var books = _bookStore.GetAll();
        return books.OrderBy(b => b.Title).ToList();
    }
    public List<Books> GetByAuthor()
    {
        var books = _bookStore.GetAll();
        return books.OrderBy(b => b.Author).ToList();
    }
    public List<Books> GetByGenere()
    {
        var books = _bookStore.GetAll();
        return books.OrderBy(b => b.Genere).ToList();
    }
    public List<Books> GetByPublisher()
    {
        var books = _bookStore.GetAll();
        return books.OrderBy(b => b.Publisher).ToList();
    }
    public List<Books> GetByYear()
    {
        return _bookStore.GetAll().OrderBy(b => b.Year).ToList();
    }
    public List<Books> GetByISBN()
    {
        var books = _bookStore.GetAll();
        return books.OrderBy(b => b.ISBN).ToList();
    }
    public List<Books> GetByIsAvailable()
    {
       var books = _bookStore.GetAll();
        return books.OrderBy(b => b.IsAvailable).ToList();
    }
    public List<Books> GetById()
    {
        var books = _bookStore.GetAll();
        return books.OrderBy(b => b.Id).ToList();
    }
    public Books? GetById(int id)
    {
        var books = _bookStore.GetAll();
        return books.FirstOrDefault(b => b.Id == id);
    }
    public Books GetByTitle(string title)
    {
        var books = _bookStore.GetAll();
        return books.FirstOrDefault(b => b.Title == title);
    }
    public Books? GetByAuthor(string author)
    {
        var books = _bookStore.GetAll();
        return books.FirstOrDefault(b => b.Author == author);
    }
    public Books? GetByGenere(string genere)
    {
        var books = _bookStore.GetAll();
        return books.FirstOrDefault(b => b.Genere == genere);
    }
    public Books? GetByPublisher(string publisher)
    {
        var books = _bookStore.GetAll();
        return books.FirstOrDefault(b => b.Publisher == publisher);
    }
    public Books? GetByYear(int year)
    {
        var books = _bookStore.GetAll();
        return books.FirstOrDefault(b => b.Year == year);
    }
    public Books? GetByISBN(string isbn)
    {
        var books = _bookStore.GetAll();
        return books.FirstOrDefault(b => b.ISBN == isbn);
    }
    public Books? GetByIsAvailable(bool isAvailable)
    {
        var books = _bookStore.GetAll();
        var list = books.Where(b => b.IsAvailable == isAvailable).ToList();
        if(list.Count == 0)
        {
            throw new Exception("No books found");
        }
        else
        {
            return list[0];
        }
    }
}