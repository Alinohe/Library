using Library.Components.CsvReader.Books;
namespace Library.Components.CsvReader;


public interface ICsvReader
{
    List<Book> ProcessBooks(string filePath);
    List<Publisher> ProcessPublisher(string filePath);
}
