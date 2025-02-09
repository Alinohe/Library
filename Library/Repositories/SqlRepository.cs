using Microsoft.EntityFrameworkCore;
using Library.Repositories;
using Library.Entities;
using Library.Data;

namespace Library.Repositories;

public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
{
    private readonly DbContext _dbContext;
    private readonly DbSet<T> _dbSet;
    private readonly Action<T> _itemAddedCallback;
    public SqlRepository(DbContext dbcontext, Action<T> itemAddedCallback = null)
    {
        _dbContext = dbcontext;
        _dbSet = dbcontext.Set<T>();
        _itemAddedCallback = itemAddedCallback;
    }

    public event EventHandler<T>? ItemAdded;
    public event EventHandler<T>? ItemRemoved;

    public IEnumerable<T> GetAll() => _dbSet.ToList();

    public T GetById(int id) => _dbSet.Find(id);

    public void Add(T item)
    {
        _dbSet.Add(item);
        _itemAddedCallback?.Invoke(item);
        ItemAdded?.Invoke(this, item);
    }

    public void Remove(T item)
    {
        _dbSet.Remove(item); ItemRemoved?.Invoke(this, item);
        ItemRemoved?.Invoke(this, item);
    }

    public void Save() => _dbContext.SaveChanges();

    //public void Update(T item) => _dbSet.Update(item);
}
