using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
	public class MovieController : Controller
	{
		private readonly IMovieService _service;

		public MovieController (IMovieService service)
		{
			_service = service;
		}

		public async Task<IActionResult> Index()
		{
			//Added the include Cinemas so I could refernece the properties in the Movie Views

			var movies = await _service.GetAllAsync(m => m.Cinema);
			return View(movies);
		}
	}
}
