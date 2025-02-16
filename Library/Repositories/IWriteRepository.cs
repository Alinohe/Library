namespace Library.Repositories;
using Library.Entities;
using Library.Repositories; 
using Library.Data;

public interface IWriteRepository<in T> where T : class, IEntity
{
    void Add(T item);
    void Update(T item);
    void Remove(T item);
    void Save();
}
