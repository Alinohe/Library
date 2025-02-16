using Library.Entities;
namespace Library.Data;
public interface IBooksData
{
    List<Books> GetByTitle();
    List<Books> GetByAuthor();
    List<Books> GetByGenere();
    List<Books> GetByPublisher();
    List<Books> GetByYear();
    List<Books> GetByISBN();
    List<Books> GetByIsAvailable();
    List<Books> GetById();

    Books? GetById(int id);
    Books? GetByTitle(string title);
    Books? GetByAuthor(string author);
    Books? GetByGenere(string genere);
    Books? GetByPublisher(string publisher);
    Books? GetByYear(int year);
    Books? GetByISBN(string isbn);
    Books? GetByIsAvailable(bool isAvailable);

}
