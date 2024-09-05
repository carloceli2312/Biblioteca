using Biblioteca.Models;

namespace Biblioteca.Services
{
    public interface IBookService
    {
        Task<Book> CreateAsync(Book book);
        Task<Book> GetByIdAsync(int id);
        Task<IEnumerable<Book>> GetAllAsync();
        Task<bool> UpdateAsync(Book book);
        Task<bool> DeleteAsync(int id);
    }
}