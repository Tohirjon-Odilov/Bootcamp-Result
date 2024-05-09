using GameStore.Etities;
using GameStore.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameStoreController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GameStoreController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Game> GetAll()
        {
            return _context.Games.ToList();
        }

        [HttpPost]
        public string Create(Game model)
        {
            _context.Games.Add(model);
            _context.SaveChanges();
            return "201";
        }

        [HttpPut]
        public string Update(int id, Game game)
        {
            var model = _context.Games.FirstOrDefault(m => m.Id == id);
            model.Name = game.Name;
            _context.Games.Update(model);
            _context.SaveChanges();
            return "202";
        }

        [HttpDelete]
        public string Delete(int id)
        {
            var model = _context.Games.FirstOrDefault(m => m.Id == id);
            _context.Games.Remove(model);
            _context.SaveChanges();
            return "203";
        }
    }
}
