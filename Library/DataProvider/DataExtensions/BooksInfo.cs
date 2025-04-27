using Library.Data.Entities;

namespace Library.BooksInfo.DataExtensions;

public static class BooksInfo
{
    public static IEnumerable<Book> ByOwner(this IEnumerable<Book> query, string title)
    {
        return query.Where(b => b.Title == title);
    }
}