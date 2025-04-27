using Library.Components.CsvReader.Books;
using Library.Components.CsvReader.Extensions;
namespace Library.Components.CsvReader;

public class CvsReader : ICvsReader
{
    public List<Book> ProcessBooks(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<Book>();
        }
        var books = File.ReadAllLines(filePath)
               .Skip(1)
               .Where(line => line.Length > 1)
               .ToBook();
        return books.ToList();
    }
    public List<Publisher> ProcessPublisher(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<Publisher>();
        }
        var publishers = File.ReadAllLines(filePath)
               .Skip(1)
               .Where(line => line.Length > 1)
               .Select(line =>
               {
                   var columns = line.Split(',');
                   return new Publisher()
                   {
                       Name = columns[0],
                       Address = columns[1],
                       Country = columns[2]
                   };

               });
        return publishers.ToList();
    }
}
