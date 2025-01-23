namespace Library.Repositories;
using Library.Entities;

public class ListRepository<T>
    where T : class, IEntity, new()
{
    private readonly List<T> _books = new();

    public IEnumerable<T> GetAll() => _books.ToList();
    public T GetById(int id) => _books.Single(book => book.Id == id);
    public T CreateNewItem() => new T();
    public void Delete(T book) => _books.Remove(book);
    public void Add(T book)
    {
        book.Id = _books.Count + 1;
        _books.Add(book);
    }
    public void Update(T book)
    {
        var existingBook = GetById(book.Id);
        existingBook = book;
    }
    public void Save()
    {
    }

}
