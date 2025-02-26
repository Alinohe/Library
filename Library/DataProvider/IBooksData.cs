using Library.Entities;
namespace Library.Data;
public interface IBooksData
{
    //Select
    List<Books> GetByTitle();
    List<Books> GetByAuthor();
    List<Books> GetByGenere();
    List<Books> GetByPublisher();
    List<Books> GetByYear();
    List<Books> GetByISBN();
    List<Books> GetByIsAvailable();
    List<Books> GetById();
    List<Books> GetAll();
    List<Books> GetByPrice(string title);
    List<Books> FilterBooks(decimal minBuyPrice);
    List<Books> FilterBooks(decimal minBuyPrice, decimal maxBuyPrice);
    List<Books> FilterBooks(decimal minBuyPrice, decimal maxBuyPrice, decimal minSellPrice);

    string AnonymusClass();
    decimal GetTotalPrice();
    decimal GetMinBuyPrice();
    decimal GetMaxBuyPrice();
    decimal GetAverageBuyPrice();
    decimal GetMinSellPrice();
    decimal GetMaxSellPrice();
    decimal GetAverageSellPrice();

    //`Insert

    Books? GetById(int id);
    Books? GetByTitle(string title);
    Books? GetByAuthor(string author);
    Books? GetByGenere(string genere);
    Books? GetByPublisher(string publisher);
    Books? GetByYear(int year);
    Books? GetByISBN(string isbn);
    Books? GetByIsAvailable(bool isAvailable);
    Books? GetByBuyPrice(decimal buyPrice);
    Books? GetBySellPrice(decimal sellPrice);

    //Take

    List<Books> TakeBooks(int count);
    List<Books> TakeBooksWithTheSameAuthor(string Author);
    List<Books> TakeBooksWithTheSameGenere(string Genere);
    List<Books> TakeBooksWithTheSamePublisher(string Publisher);
    List<Books> TakeBooksWhileStartsWith(String prefix);

    //distinct
    List<Books> DistinctByAuthors();
    List<string> DistinctAllAuthors();

    //Chunk
    List<Books[]> ChunkBooks(int size);

}
