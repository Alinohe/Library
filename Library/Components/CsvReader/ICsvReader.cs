using Library.Components.CsvReader.Books;
namespace Library.Components.CsvReader;

public interface ICsvReader
{
    List<Books.Books> ProcessBooks(string filePath);
    List<Publisher> ProcessPublisher(string filePath);
}
