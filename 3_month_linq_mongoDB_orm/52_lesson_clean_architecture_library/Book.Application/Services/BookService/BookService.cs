using Book.Application.Abstractions.Repositories;
using Book.Application.DataTransferObjects;
using Book.Domain.Entities;

namespace Book.Application.Services.Book
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _BookRepository;

        public BookService(IBookRepository BookRepository)
            => _BookRepository = BookRepository;

        public async Task<Book> InsertAsync(BookDTO BookDTO)
        {
            var Book = new Book()
            {
                Name = BookDTO.Name
            };

            Book = await _BookRepository.InsertAsync(Book);

            return Book;
        }

        public async Task<List<Book>> SelectAllAsync()
            => await _BookRepository.SelectAllAsync();

        public async Task<Book> SelectByIdAsync(long id)
            => await _BookRepository.SelectByIdAsync(id);

        public async Task<Book> UpdateAsync(BookDTO BookDTO, long id)
        {
            var Book = new Book()
            {
                Name = BookDTO.Name
            };

            var gerne = await _BookRepository.UpdateAsync(Book, id);

            return Book;
        }

        public async Task<Book> DeleteAsync(long id)
        {
            var Book = await _BookRepository.DeleteAsync(id);

            return Book;
        }
    }
}
