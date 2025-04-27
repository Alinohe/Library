using Library.Components.CsvReader.Books;

namespace Library.Components.CsvReader.Extensions;

public static class BookExtensions
{
    public static IEnumerable<Book> ToBook(this IEnumerable<string> source)
    {
        foreach (var line in source)
        {
            var col = line.Split(',');
            yield return new Book
            {
                Title = col[0],
                Author = col[1],
                Genere = col[2],
                Publisher = col[3],
                Year = int.TryParse(col[4], out var year) ? year : (int?)null,
                ISBN = col[5],
                IsAvailable = bool.TryParse(col[6], out var isAvailable) ? isAvailable : (bool?)null,
                DateOfBorrow = DateTime.TryParse(col[7], out var dateOfBorrow) ? dateOfBorrow : (DateTime?)null,
                BuyPrice = decimal.TryParse(col[8], out var buyPrice) ? buyPrice : (decimal?)null,
                SellPrice = decimal.TryParse(col[9], out var sellPrice) ? sellPrice : (decimal?)null
            };
        }
    }
}