namespace Library.Repositories;
using Microsoft.EntityFrameworkCore;
using Library.Entities;

internal class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
{
    private readonly DbContext _dbContext;
    private readonly DbSet<T> _dbSet;
    public SqlRepository(DbContext dbcontext)
    {
        _dbContext = dbcontext;
        _dbSet = dbcontext.Set<T>();
    }
    public IEnumerable<T> GetAll() => _dbSet.ToList();
        public T GetById(int id) => _dbSet.Find(id);
    public void Add(T book) => _dbSet.Add(book);
    public void Save() => _dbContext.SaveChanges();
    public void Delete(T book) => _dbSet.Remove(book);
    public void Update(T book) => _dbSet.Update(book);
}
