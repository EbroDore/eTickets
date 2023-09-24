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

        public async Task<IActionResult> Filter(string searchString)
        {

            //Added the include Cinemas so I could refernece the properties in the Movie Views

            var movies = await _service.GetAllAsync(m => m.Cinema);

			if (!string.IsNullOrEmpty(searchString))
			{
				var filteredResult = movies.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString))
					.ToList();
				return View("Index", filteredResult);
			}
            return View("Index", movies);
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


		//GET: Movies/Edit/1
		
		public async Task<IActionResult> Edit(int id)
		{
			var movieDetails = await _service.GetMovieByIdAsync(id);

			if (movieDetails == null)
			{
				return NotFound();
			}

			var response = new NewMovieVM()
			{
				Id = movieDetails.Id,
				Name = movieDetails.Name,
				Description = movieDetails.Description,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                Price = movieDetails.Price,
				ImageURL = movieDetails.ImageURL,
				MovieCategory = movieDetails.MovieCategory,
				CinemaId = movieDetails.CinemaId,
				ProducerId = movieDetails.ProducerId,
				ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList(),
				
			};

			var movieDropdownsData = await _service.GetNewMovieDropDownsValues();

			ViewBag.CinemaId = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
			ViewBag.ProducerId = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
			ViewBag.ActorId = new SelectList(movieDropdownsData.Actors, "Id", "FullName");



			return View(response);

        }

		[HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
			if(id != movie.Id)
			{
				return NotFound();

			}

			if (!ModelState.IsValid)
			{

                var movieDropdownsData = await _service.GetNewMovieDropDownsValues();

                ViewBag.CinemaId = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.ProducerId = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.ActorId = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

				return View(movie);
            }



			await _service.UpdateNewMovieAsync(movie);

            return RedirectToAction(nameof(Index));
        }



    }
}
