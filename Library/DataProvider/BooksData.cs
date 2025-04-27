using Library.Data.Entities;
using Library.Data.Repositories;
using System.Text;
namespace Library.Data;

public class BooksData : IBooksData
{
    private readonly IRepository<Book> _bookRepos;
    public BooksData(IRepository<Book> bookRepos)
    {
        _bookRepos = bookRepos;
    }

    public List<Book> GetSpecificColumns()
    {
        var books = _bookRepos.GetAll();
        var list = books.Select(b => new Book
        {
            Title = b.Title,
            Author = b.Author,
            Genere = b.Genere,
            Year = b.Year,
        }).ToList();
        return list;
    }

    public List<Book> GetByTitle()
    {
        var books = _bookRepos.GetAll();
        return books.OrderBy(b => b.Title).ToList();
    }
    public List<Book> GetByAuthor()
    {
        var books = _bookRepos.GetAll();
        return books.OrderBy(b => b.Author).ToList();
    }
    public List<Book> GetByGenere()
    {
        var books = _bookRepos.GetAll();
        return books.OrderBy(b => b.Genere).ToList();
    }
    public List<Book> GetByPublisher()
    {
        var books = _bookRepos.GetAll();
        return books.OrderBy(b => b.Publisher).ToList();
    }
    public List<Book> GetByYear()
    {
        return _bookRepos.GetAll().OrderBy(b => b.Year).ToList();
    }
    public List<Book> GetByISBN()
    {
        var books = _bookRepos.GetAll();
        return books.OrderBy(b => b.ISBN).ToList();
    }
    public List<Book> GetByIsAvailable()
    {
        var books = _bookRepos.GetAll();
        return books.OrderBy(b => b.IsAvailable).ToList();
    }
    public List<Book> GetById()
    {
        var books = _bookRepos.GetAll();
        return books.OrderBy(b => b.Id).ToList();
    }
    public Book? GetById(int id)
    {
        var books = _bookRepos.GetAll();
        return books.FirstOrDefault(b => b.Id == id);
    }
    public Book GetByTitle(string title)
    {
        var books = _bookRepos.GetAll();
        return books.FirstOrDefault(b => b.Title == title);
    }
    public Book? GetByAuthor(string author)
    {
        var books = _bookRepos.GetAll();
        return books.FirstOrDefault(b => b.Author == author);
    }
    public Book? GetByGenere(string genere)
    {
        var books = _bookRepos.GetAll();
        return books.FirstOrDefault(b => b.Genere == genere);
    }
    public Book? GetByPublisher(string publisher)
    {
        var books = _bookRepos.GetAll();
        return books.FirstOrDefault(b => b.Publisher == publisher);
    }
    public Book? GetByYear(int year)
    {
        var books = _bookRepos.GetAll();
        return books.FirstOrDefault(b => b.Year == year);
    }
    public Book? GetByISBN(string isbn)
    {
        var books = _bookRepos.GetAll();
        return books.FirstOrDefault(b => b.ISBN == isbn);
    }
    public Book? GetByIsAvailable(bool isAvailable)
    {
        var books = _bookRepos.GetAll();
        var list = books.Where(b => b.IsAvailable == isAvailable).ToList();
        if (list.Count == 0)
        {
            throw new Exception("No books found");
        }
        else
        {
            return list[0];
        };
    }

    public string AnonymusClass()
    {
        var books = _bookRepos.GetAll();
        var list = books.Select(b => new
        {
            Title = b.Title,
            Author = b.Author,
            Genere = b.Genere,
            Publisher = b.Publisher,
            Year = b.Year,
            ISBN = b.ISBN,
            IsAvailable = b.IsAvailable,
            DateOfBorrow = b.DateOfBorrow,
            BuyPrice = b.BuyPrice,
            SellPrice = b.SellPrice
        }).ToList();

        StringBuilder sb = new(2048);
        foreach (var book in list)
        {
            sb.AppendLine($"Title: {book.Title}");
            sb.AppendLine($"Author: {book.Author}");
            sb.AppendLine($"Genere: {book.Genere}");
            sb.AppendLine($"Year: {book.Year}");
            sb.AppendLine($"IsAvailable: {book.IsAvailable}");
            sb.AppendLine($"BuyPrice: {book.BuyPrice}");
            sb.AppendLine($"SellPrice: {book.SellPrice}");
        }
        return sb.ToString();
    }

    public List<Book> GetAll()
    {
        throw new NotImplementedException();
    }

    public List<Book> GetByPrice(string title)
    {
        throw new NotImplementedException();
    }

    public List<Book> FilterBooks(decimal minBuyPrice)
    {
        var books = _bookRepos.GetAll();
        var list = new List<Book>();
        foreach (var book in books)
        {
            if (book.BuyPrice >= minBuyPrice)
            {
                list.Add(book);
            }
        }
        return list;
    }

    public List<Book> FilterBooks(decimal minBuyPrice, decimal maxBuyPrice)
    {
        var books = _bookRepos.GetAll();
        var list = new List<Book>();
        foreach (var book in books)
        {
            if (book.BuyPrice >= minBuyPrice && book.BuyPrice <= maxBuyPrice)
            {
                list.Add(book);
            }
        }
        return list;
    }

    public List<Book> FilterBooks(decimal minBuyPrice, decimal maxBuyPrice, decimal minSellPrice)
    {
        var books = _bookRepos.GetAll();
        var list = new List<Book>();
        foreach (var book in books)
        {
            if (book.BuyPrice >= minBuyPrice && book.BuyPrice <= maxBuyPrice && book.SellPrice >= minSellPrice)
            {
                list.Add(book);
            }
        }
        return list;
    }

    public decimal GetTotalPrice()
    {
        var books = _bookRepos.GetAll();
        return (decimal)books.Sum(b => b.BuyPrice);
    }

    public decimal GetMinBuyPrice()
    {
        var books = _bookRepos.GetAll();
        return (decimal)books.Min(b => b.BuyPrice);

    }

    public decimal GetMaxBuyPrice()
    {
        var books = _bookRepos.GetAll();
        return (decimal)books.Max(b => b.BuyPrice);
    }

    public decimal GetAverageBuyPrice()
    {
        var books = _bookRepos.GetAll();
        return (decimal)books.Average(b => b.BuyPrice);
    }

    public decimal GetMinSellPrice()
    {
        var books = _bookRepos.GetAll();
        return (decimal)books.Min(b => b.SellPrice);
    }

    public decimal GetMaxSellPrice()
    {
        var books = _bookRepos.GetAll();
        return (decimal)books.Max(b => b.SellPrice);
    }

    public decimal GetAverageSellPrice()
    {
        var books = _bookRepos.GetAll();
        return (decimal)books.Average(b => b.SellPrice);
    }

    public Book? GetByBuyPrice(decimal buyPrice)
    {
        var books = _bookRepos.GetAll();
        return books.FirstOrDefault(b => b.BuyPrice == buyPrice);
    }

    public Book? GetBySellPrice(decimal sellPrice)
    {
        var books = _bookRepos.GetAll();
        return books.FirstOrDefault(b => b.SellPrice == sellPrice);
    }

    public List<Book> TakeBooks(int count)
    {
        var books = _bookRepos.GetAll();
        return books.Take(count).ToList();
    }

    public List<Book> TakeBooksWithTheSameAuthor(string Author)
    {
        var books = _bookRepos.GetAll();
        return books.Where(b => b.Author == Author).ToList();
    }

    public List<Book> TakeBooksWithTheSameGenere(string Genere)
    {
        var books = _bookRepos.GetAll();
        return books.Where(b => b.Genere == Genere).ToList();
    }

    public List<Book> TakeBooksWithTheSamePublisher(string Publisher)
    {
        var books = _bookRepos.GetAll();
        return books.Where(b => b.Publisher == Publisher).ToList();
    }

    public List<Book> TakeBooksWhileStartsWith(string prefix)
    {
        var books = _bookRepos.GetAll();
        return books.Where(b => b.Title.StartsWith(prefix)).ToList();
    }

    public List<Book> DistinctByAuthors()
    {
        var books = _bookRepos.GetAll();
        return books.Distinct().ToList();
    }

    public List<string> DistinctAllAuthors()
    {
        var books = _bookRepos.GetAll();
        return books.Select(b => b.Author).Distinct().ToList();
    }

    public List<Book[]> ChunkBooks(int size)
    {
        var books = _bookRepos.GetAll();
        return books.Chunk(size).ToList();
    }
}