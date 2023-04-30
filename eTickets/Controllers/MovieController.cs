using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
	public class MovieController : Controller
	{
		private readonly ApplicationDbContext _context;

		public MovieController(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			//Added the include Cinemas so I could refernece the properties in the Movie Views

			var movies = await _context.Movies
				.Include(c => c.Cinema)
				.ToListAsync();
			return View(movies);
		}
	}
}
