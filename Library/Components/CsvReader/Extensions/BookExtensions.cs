namespace Library.Components.CsvReader.Extensions;

public static class BookExtensions
{
    public static IEnumerable<Books.Books> ToBook(this IEnumerable<string> source)
    {
        foreach (var line in source)
        {
            var col = line.Split(',');
            yield return new Books.Books
            {
                Title = col[0],
                Author = col[1],
                Genere = col[2],
                Volume = col[3],
                Publisher = col[4],

                //Year = int.TryParse(col[5], out var year) ? year : (int?)null,
                //ISBN = col[6],
                //IsAvailable = bool.TryParse(col[7], out var isAvailable) ? isAvailable : (bool?)null,
                //DateOfBorrow = DateTime.TryParse(col[8], out var dateOfBorrow) ? dateOfBorrow : (DateTime?)null,
                //BuyPrice = decimal.TryParse(col[9], out var buyPrice) ? buyPrice : (decimal?)null,
                //SellPrice = decimal.TryParse(col[10], out var sellPrice) ? sellPrice : (decimal?)null
            };
        }
    }
}