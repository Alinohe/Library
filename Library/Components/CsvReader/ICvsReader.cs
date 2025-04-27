using Library.Components.CsvReader.Books;
namespace Library.Components.CsvReader;


public interface ICvsReader
{
    List<Book> ProcessBooks(string filePath);
    List<Publisher> ProcessPublisher(string filePath);
}
