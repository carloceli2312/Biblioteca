using Biblioteca.Data;
using Biblioteca.Models;

namespace Biblioteca.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryContext _context;
        public BookService(LibraryContext context)
        {
            _context = context;
        }

        public Book Create()
        {
            throw new NotImplementedException();
        }

        public bool DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public Book Read(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Book book)
        {
            throw new NotImplementedException();
        }
    }
}