using _51_lesson_EntityFramework_Intro.Applications.PhoneService;
using _51_lesson_EntityFramework_Intro.Applications.PhoneService;
using _51_lesson_EntityFramework_Intro.DTOs;

//using _51_lesson_EntityFramework_Intro.DTOs;
using _51_lesson_EntityFramework_Intro.Models;
using Microsoft.AspNetCore.Mvc;

namespace _51_lesson_EntityFramework_Intro.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EntityController : ControllerBase
    {
        private readonly IPhoneservice _PhoneService;


        public EntityController(IPhoneservice PhoneService)
        {
            _PhoneService = PhoneService;
        }

        [HttpPost]
        public async Task<string> CreatePhone(PhoneDTO model)
        {
            try
            {
                var _model = new Phone()
                {
                    Name = model.Name,
                    Price = model.Price,
                    Brand = model.Brand,
                    year = model.year,
                };
                return await _PhoneService.CreatePhoneAsync(_model);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPhoneAsync()
        {
            try
            {
                var result = await _PhoneService.GetAllPhoneAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPhoneByIdAsync(int id)
        {
            try
            {
                var result = await _PhoneService.GetPhoneByIdAsync(id);

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
        public async Task<IActionResult> UpdatePhoneAsync(int id, PhoneDTO model)
        {
            try
            {
                var _model = new Phone()
                {
                    Name = model.Name,
                    Brand = model.Brand,
                    Price = model.Price,
                    year = model.year
                };

                await _PhoneService.UpdatePhoneAsync(id, _model);

                return Ok("Ma'lumot yangilandi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePhoneAsync(int id)
        {
            try
            {
                await _PhoneService.DeletePhoneByIdAsync(id);

                return Ok("Ma'lumot yangilandi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
