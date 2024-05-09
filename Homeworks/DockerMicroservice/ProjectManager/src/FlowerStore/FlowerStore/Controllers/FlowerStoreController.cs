using FlowerStore.Etities;
using FlowerStore.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlowerStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowerStoreController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FlowerStoreController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Flower> GetAll()
        {
            return _context.Flowers.ToList();
        }

        [HttpPost]
        public string Create(Flower model)
        {
            _context.Flowers.Add(model);
            _context.SaveChanges();
            return "201";
        }

        [HttpPut]
        public string Update(int id, Flower flower)
        {
            var model = _context.Flowers.FirstOrDefault(m => m.Id == id);
            model.Name = flower.Name;
            _context.Flowers.Update(model);
            _context.SaveChanges();
            return "202";
        }

        [HttpDelete]
        public string Delete(int id)
        {
            var model = _context.Flowers.FirstOrDefault(m => m.Id == id);
            _context.Flowers.Remove(model);
            _context.SaveChanges();
            return "203";
        }
    }
}
