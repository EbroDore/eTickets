using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

		public async Task<IActionResult> Details(int id)
		{
			var movie = await _service.GetMovieByIdAsync(id);
			return View(movie);
		}
		
		//
		public async Task<IActionResult> Create()
		{
			var movieDropdownsData = await _service.GetNewMovieDropDownsValues();

			ViewBag.CinemaId = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
			ViewBag.ProducerId = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
			ViewBag.ActorId = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View();
		}

		[HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {

			if (!ModelState.IsValid)
			{
                var movieDropdownsData = await _service.GetNewMovieDropDownsValues();

                ViewBag.CinemaId = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.ProducerId = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.ActorId = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
                return View(movie);
			}

			await _service.AddNewMovieAsync(movie);
			return RedirectToAction(nameof(Index));
        }


    }
}
