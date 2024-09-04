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
    public class BookViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Book> _books;
        private Book _selectedBook;
        private readonly IBookService _bookService;

        //sostituire operazione nel contesto col servizio
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

        public async Task AddBook()
        {
            _books.Add(_bookService.Create());
        }

        public async Task ReadBook(Book book)
        {
            await _bookService.Read(book.id);
        }

        public async Task DeleteBook(Book book)
        {
            _books.Remove(book);
            await _bookService.Delete(book.Id);
        }

        public async Task UpdateBook(Book book)
        {
            await _bookService.Update(book);
        }
    }
}

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}