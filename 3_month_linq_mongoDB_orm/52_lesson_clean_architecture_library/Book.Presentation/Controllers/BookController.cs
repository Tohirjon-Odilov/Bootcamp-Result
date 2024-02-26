using Microsoft.AspNetCore.Mvc;

namespace Book.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;


        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public async Task<string> CreateBook(BookDTO model)
        {
            try
            {
                var _model = new Book()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Author = model.Author,
                    Price = model.Price,
                };
                return await _bookService.CreateBookAsync(_model);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookAsync()
        {
            try
            {
                var result = await _bookService.GetAllBookAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetBookByIdAsync(int id)
        {
            try
            {
                var result = await _bookService.GetBookByIdAsync(id);

                if (result is null)
                {
                    return NotFound("Ma'lumot topilmadi");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBookAsync(int id, BookDTO model)
        {
            try
            {
                var _model = new Book()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    Author = model.Author
                };

                await _bookService.UpdateBookAsync(id, _model);

                return Ok("Ma'lumot yangilandi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBookAsync(int id)
        {
            try
            {
                await _bookService.DeleteBookByIdAsync(id);

                return Ok("Ma'lumot yangilandi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
