using Library.Entities;
using Library.Repositories;
using System.Text;
namespace Library.Data;

public class BooksData : IBooksData
{
    private readonly IRepository<Books> _bookStore;
    public BooksData(IRepository<Books> bStore)
    {
        _bookStore = bStore;
    }

    public List<Books> GetSpecificColumns()
    {
        var books = _bookStore.GetAll();
        var list = books.Select(b => new Books
        {
            Title = b.Title,
            Author = b.Author,
            Genere = b.Genere,
            Year = b.Year,
        }).ToList();
        return list;
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
        var books = _bookStore.GetAll();
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


    public List<Books> GetAll()
    {
        throw new NotImplementedException();
    }

    public List<Books> GetByPrice(string title)
    {
        throw new NotImplementedException();
    }

    public List<Books> FilterBooks(decimal minBuyPrice)
    {
        var books = _bookStore.GetAll();
        var list = new List<Books>();
        foreach (var book in books)
        {
            if (book.BuyPrice >= minBuyPrice)
            {
                list.Add(book);
            }
        }
        return list;
    }

    public List<Books> FilterBooks(decimal minBuyPrice, decimal maxBuyPrice)
    {
        var books = _bookStore.GetAll();
        var list = new List<Books>();
        foreach (var book in books)
        {
            if (book.BuyPrice >= minBuyPrice && book.BuyPrice <= maxBuyPrice)
            {
                list.Add(book);
            }
        }
        return list;
    }

    public List<Books> FilterBooks(decimal minBuyPrice, decimal maxBuyPrice, decimal minSellPrice)
    {
        var books = _bookStore.GetAll();
        var list = new List<Books>();
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
        var books = _bookStore.GetAll();
        return (decimal)books.Sum(b => b.BuyPrice);
    }

    public decimal GetMinBuyPrice()
    {
        var books = _bookStore.GetAll();
        return (decimal)books.Min(b => b.BuyPrice);

    }

    public decimal GetMaxBuyPrice()
    {
        var books = _bookStore.GetAll();
        return (decimal)books.Max(b => b.BuyPrice);
    }

    public decimal GetAverageBuyPrice()
    {
        var books = _bookStore.GetAll();
        return (decimal)books.Average(b => b.BuyPrice);
    }

    public decimal GetMinSellPrice()
    {
        var books = _bookStore.GetAll();
        return (decimal)books.Min(b => b.SellPrice);
    }

    public decimal GetMaxSellPrice()
    {
        var books = _bookStore.GetAll();
        return (decimal)books.Max(b => b.SellPrice);
    }

    public decimal GetAverageSellPrice()
    {
        var books = _bookStore.GetAll();
        return (decimal)books.Average(b => b.SellPrice);
    }

    public Books? GetByBuyPrice(decimal buyPrice)
    {
        var books = _bookStore.GetAll();
        return books.FirstOrDefault(b => b.BuyPrice == buyPrice);
    }

    public Books? GetBySellPrice(decimal sellPrice)
    {
        var books = _bookStore.GetAll();
        return books.FirstOrDefault(b => b.SellPrice == sellPrice);
    }

    public List<Books> TakeBooks(int count)
    {
        var books = _bookStore.GetAll();
        return books.Take(count).ToList();
    }

    public List<Books> TakeBooksWithTheSameAuthor(string Author)
    {
        var books = _bookStore.GetAll();
        return books.Where(b => b.Author == Author).ToList();
    }

    public List<Books> TakeBooksWithTheSameGenere(string Genere)
    {
        var books = _bookStore.GetAll();
        return books.Where(b => b.Genere == Genere).ToList();
    }

    public List<Books> TakeBooksWithTheSamePublisher(string Publisher)
    {
        var books = _bookStore.GetAll();
        return books.Where(b => b.Publisher == Publisher).ToList();
    }

    public List<Books> TakeBooksWhileStartsWith(string prefix)
    {
        var books = _bookStore.GetAll();
        return books.Where(b => b.Title.StartsWith(prefix)).ToList();
    }

    public List<Books> DistinctByAuthors()
    {
        var books = _bookStore.GetAll();
        return books.Distinct().ToList();
    }

    public List<string> DistinctAllAuthors()
    {
        var books = _bookStore.GetAll();
        return books.Select(b => b.Author).Distinct().ToList();
    }

    public List<Books[]> ChunkBooks(int size)
    {
        var books = _bookStore.GetAll();
        return books.Chunk(size).ToList();
    }
}