using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Biblioteca.Data;
using Biblioteca.Models;
using Biblioteca.Services;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.ViewModels
{
    //sostituire operazione nel contesto col servizio
    public class BookViewModel : INotifyPropertyChanged
    {
        private readonly LibraryContext _context;
        private ObservableCollection<Book> _books;
        private Book _selectedBook;

        private readonly IBookService _bookService;

        public BookViewModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        public ObservableCollection<Book> Books
        {
            get => _books;
            set
            {
                _books = value;
                OnPropertyChanged();
            }
        }

        public Book SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                OnPropertyChanged();
            }
        }

        public BookViewModel(LibraryContext context)
        {
            _context = context;
            Books = new ObservableCollection<Book>();
        }

        public async Task LoadBooksAsync()
        {
            var books = await _context.Books.ToListAsync();
            Books = new ObservableCollection<Book>(books);
        }

        public async Task AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            await LoadBooksAsync();
        }

        public async Task UpdateBookAsync(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            await LoadBooksAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                await LoadBooksAsync();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}