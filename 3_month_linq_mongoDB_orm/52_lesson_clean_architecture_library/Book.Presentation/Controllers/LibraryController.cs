using Microsoft.AspNetCore.Mvc;

namespace Book.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly IBookService _libraryService;


        public LibraryController(IBookService bookService)
        {
            _libraryService = bookService;
        }

        [HttpPost]
        public async Task<string> CreateBook(LibraryDTO model)
        {
            try
            {
                var _model = new Library()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Librarier = model.Librarier,
                    Address = model.Address,
                };
                return await _libraryService.CreateLibraryAsync(_model);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLibraryAsync()
        {
            try
            {
                var result = await _libraryService.GetAllLibraryAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetLibraryByIdAsync(int id)
        {
            try
            {
                var result = await _libraryService.GetLibraryByIdAsync(id);

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
        public async Task<IActionResult> UpdateLibraryAsync(int id, LibraryDTO model)
        {
            try
            {
                var _model = new Library()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Librarier = model.Librarier,
                    Address = model.Address,
                };

                await _libraryService.UpdateLibraryAsync(id, _model);

                return Ok("Ma'lumot yangilandi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLibraryAsync(int id)
        {
            try
            {
                await _libraryService.DeleteLibraryByIdAsync(id);

                return Ok("Ma'lumot yangilandi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
