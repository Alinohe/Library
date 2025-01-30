namespace Library.Repositories;
using Library.Entities;

public interface IReadRepository<out T> where T : class, IEntity
{
    IEnumerable<T> GetAll();
    T? GetById(int id);
}
