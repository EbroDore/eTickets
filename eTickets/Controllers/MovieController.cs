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
			var movies = await _context.Movies.ToListAsync();
			return View(movies);
		}
	}
}
