using Library.Entities;


namespace Library.BooksInfo.DataExtensions;

public static class BooksInfo
{
    public static IEnumerable<Books> ByOwner(this IEnumerable<Books> query, string title)
    {
        return query.Where(x => x.Title == title);
    }
}