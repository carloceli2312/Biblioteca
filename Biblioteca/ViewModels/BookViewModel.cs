using Biblioteca.Models;
using Biblioteca.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;

namespace Biblioteca.ViewModels
{
    public class BookViewModel
    {
        private readonly IBookService _bookService;

        public ObservableCollection<Book> Books { get; private set; } = new ObservableCollection<Book>();
        public Book? SelectedBook { get; set; }

        public BookViewModel(IBookService bookService, NavigationManager navigationManager)
        {
            _bookService = bookService;
        }

        public async Task LoadBooksAsync()
        {
            var books = await _bookService.GetAllAsync();
            Books.Clear();
            foreach (var book in books)
            {
                Books.Add(book);
            }
        }

        public async Task AddBookAsync(Book book)
        {
            await _bookService.CreateAsync(book);
            Books.Add(book);
        }

        public async Task UpdateBookAsync(Book book)
        {
            if (await _bookService.UpdateAsync(book))
            {
                var index = Books.IndexOf(Books.First(b => b.Id == book.Id));
                Books[index] = book;
            }
        }

        public async Task DeleteBookAsync(int id)
        {
            if (await _bookService.DeleteAsync(id))
            {
                var bookToRemove = Books.First(b => b.Id == id);
                Books.Remove(bookToRemove);
            }
        }
        
    }
}