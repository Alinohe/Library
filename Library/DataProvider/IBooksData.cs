using Library.Data.Entities;

namespace Library.Data;
public interface IBooksData
{
    //Select
    List<Book> GetByTitle();
    List<Book> GetByAuthor();
    List<Book> GetByGenere();
    List<Book> GetByVolume();
    List<Book> GetByPublisher();
    List<Book> GetByYear();
    List<Book> GetByISBN();
    List<Book> GetByIsAvailable();
    List<Book> GetById();
    List<Book> GetAll();
    List<Book> GetByPrice(string title);
    List<Book> FilterBooks(decimal minBuyPrice);
    List<Book> FilterBooks(decimal minBuyPrice, decimal maxBuyPrice);
    List<Book> FilterBooks(decimal minBuyPrice, decimal maxBuyPrice, decimal minSellPrice);

    string AnonymusClass();
    decimal GetTotalPrice();
    decimal GetMinBuyPrice();
    decimal GetMaxBuyPrice();
    decimal GetAverageBuyPrice();
    decimal GetMinSellPrice();
    decimal GetMaxSellPrice();
    decimal GetAverageSellPrice();

    //`Insert

    Book? GetById(int id);
    Book? GetByTitle(string title);
    Book? GetByAuthor(string author);
    Book? GetByGenere(string genere);
    Book? GetByPublisher(string publisher);
    Book? GetByYear(int year);
    Book? GetByISBN(string isbn);
    Book? GetByIsAvailable(bool isAvailable);
    Book? GetByBuyPrice(decimal buyPrice);
    Book? GetBySellPrice(decimal sellPrice);

    //Take

    List<Book> TakeBooks(int count);
    List<Book> TakeBooksWithTheSameAuthor(string Author);
    List<Book> TakeBooksWithTheSameGenere(string Genere);
    List<Book> TakeBooksWithTheSamePublisher(string Publisher);
    List<Book> TakeBooksWhileStartsWith(String prefix);

    //distinct
    List<Book> DistinctByAuthors();
    List<string> DistinctAllAuthors();

    //Chunk
    List<Book[]> ChunkBooks(int size);

}
