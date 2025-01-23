using Library.Entities;

namespace Library.Repositories;

public interface IWriteRepository<in T> where T : class, IEntity
{
    void Add(T book);
    void Update(T book);
    void Delete(T book);
    void Save();
}
