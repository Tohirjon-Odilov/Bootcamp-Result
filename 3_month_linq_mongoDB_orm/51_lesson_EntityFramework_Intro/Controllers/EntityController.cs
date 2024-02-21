using _51_lesson_EntityFramework_Intro.Applications.PhoneService;
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
        public async Task<string> CreatePhone(Phone model)
        {
            var result = await _PhoneService.CreatePhoneAsync(model);

            return result;
        }

        [HttpPost]
        public async Task<string> CreatePhoneStore(PhoneStore model)
        {
            var result = await _PhoneService.CreatePhoneStoreAsync(model);
        }
    }
}
