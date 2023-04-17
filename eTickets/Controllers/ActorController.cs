using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ActorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActorController(ApplicationDbContext context)
        {
                _context = context;
        }
        public async Task<IActionResult> Index()
        {
             var actor = await _context.Actors.ToListAsync();

			if (actor == null)
			{
				return NotFound();
			}

			return View(actor);
        }
    }
}
