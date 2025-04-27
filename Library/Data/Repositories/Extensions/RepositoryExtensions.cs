namespace Library.Data.Repositories.Extensions;

using Library.Data.Entities;
using Library.Data.Repositories;

public static class RepositoryExtensions
{
    public static void AddBatch<T>(this IRepository<T> repository, T[] items)
        where T : class, IEntity
    {
        foreach (var item in items)
        {
            repository.Add(item);
        }
        repository.Save();
    }

    public static void AddBatch<T>(this IRepository<T> repository, string message, T[] items)
        where T : class, IEntity
    {
        Console.WriteLine(message);
        repository.AddBatch(items);
    }

    public static void AddBatch<T>(this string str, T[] items)
        where T : class, IEntity
    {

    }
}
