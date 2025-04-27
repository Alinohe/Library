namespace Library.Data.Repositories;

using Library.Data.Entities;

public interface IWriteRepository<in T> where T : class, IEntity
{
    void Add(T item);
    void Update(T item);
    void Remove(T item);
    void Save();
}
