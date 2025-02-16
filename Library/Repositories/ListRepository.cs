namespace Library.Repositories;
using Library.Entities;
public class ListRepository<T>
    where T : class, IEntity, new()
{
    private readonly List<T> _items = new();

    public IEnumerable<T> GetAll() => _items.ToList();
    public T GetById(int id) => _items.Single(item => item.Id == id);
    public void Remove(T item) => _items.Remove(item);
    public void Add(T item)
    {
        item.Id = _items.Count + 1;
        _items.Add(item);
    }
    public void Update(T item)
    {
        var existingBook = GetById(item.Id);
        existingBook = item;
    }
    public void Save()
    {
    }
}
