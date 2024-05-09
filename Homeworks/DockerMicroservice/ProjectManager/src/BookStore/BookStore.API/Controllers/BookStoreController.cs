using BookStore.API.Entities;
using BookStore.API.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookStoreController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookStoreController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        [HttpPost]
        public string Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges(); 
            return "201";
        }

        [HttpPut]
        public string Update(int id,Book book)
        {
            var model = _context.Books.FirstOrDefault(m => m.Id == id);
            model.Name = book.Name;
            _context.Books.Update(model);
            _context.SaveChanges();
            return "202";
        }

        [HttpDelete]
        public string Delete(int id)
        {
            var model = _context.Books.FirstOrDefault(m => m.Id == id);
            _context.Books.Remove(model);
            _context.SaveChanges();
            return "203";
        }
    }
}
