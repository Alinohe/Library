using Library.Components.CsvReader.Books;
using Library.Components.CsvReader.Extensions;
namespace Library.Components.CsvReader;

public class CvsReader : ICsvReader
{
    public List<Books.Books> ProcessBooks(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<Books.Books>();
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
