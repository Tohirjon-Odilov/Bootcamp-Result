using CarStore.Etities;
using CarStore.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarStoreController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarStoreController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Car> GetAll()
        {
            return _context.Cars.ToList();
        }

        [HttpPost]
        public string Create(Car model)
        {
            _context.Cars.Add(model);
            _context.SaveChanges();
            return "201";
        }

        [HttpPut]
        public string Update(int id, Car car)
        {
            var model = _context.Cars.FirstOrDefault(m => m.Id == id);
            model.Name = car.Name;
            _context.Cars.Update(model);
            _context.SaveChanges();
            return "202";
        }

        [HttpDelete]
        public string Delete(int id)
        {
            var model = _context.Cars.FirstOrDefault(m => m.Id == id);
            _context.Cars.Remove(model);
            _context.SaveChanges();
            return "203";
        }
    }
}
