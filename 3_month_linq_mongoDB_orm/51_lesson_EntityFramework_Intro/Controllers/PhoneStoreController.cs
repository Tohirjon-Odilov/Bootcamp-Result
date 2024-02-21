using _51_lesson_EntityFramework_Intro.Applications.PhoneStoreService;
using _51_lesson_EntityFramework_Intro.DTOs;
using _51_lesson_EntityFramework_Intro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _51_lesson_EntityFramework_Intro.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PhoneStoreController : ControllerBase
    {

        private readonly IPhoneStoreService _phoneStoreService;
        public PhoneStoreController(IPhoneStoreService phoneStoreService)
        {
            _phoneStoreService = phoneStoreService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePhoneStore(PhoneStoreDTO model)
        {
            try
            {
                var _model = new PhoneStore()
                {
                    PhoneId = model.PhoneId,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    Saller = model.Saller,
                };
                await _phoneStoreService.CreatePhoneStoreAsync(_model);

                return Ok("Ma'lumot yaratildi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPhoneStoreAsync()
        {
            try
            {
                var result = await _phoneStoreService.GetAllPhoneStoreAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPhoneStoreByIdAsync(int id)
        {
            try
            {
                var result = await _phoneStoreService.GetPhoneStoreByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePhoneStoreAsync(int id,  PhoneStoreDTO model)
        {
            try
            {
                var _model = new PhoneStore()
                {
                    PhoneId = model.PhoneId,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    Saller = model.Saller,
                };

                await _phoneStoreService.UpdatePhoneStoreAsync(id, _model);

                return Ok("Ma'lumot yangilandi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePhoneStoreAsync(int id)
        {
            try
            {
                await _phoneStoreService.DeletePhoneStoreByIdAsync(id);

                return Ok("Ma'lumot o'chirildi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
