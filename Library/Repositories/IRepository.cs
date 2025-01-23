namespace Library.Repositories;
using Library.Entities;

public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
    where T : class, IEntity
{
}
