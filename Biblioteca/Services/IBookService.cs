using Biblioteca.Models;

namespace Biblioteca.Services
{
    public interface IBookService
    {
        Book Create();
        Book Read(int id);
        bool Update(Book book);
        bool DeleteBook(int id);

    }
}