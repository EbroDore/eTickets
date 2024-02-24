using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
	public class CinemaController : Controller
	{
		private readonly ICinemaService _service;

        public CinemaController(ICinemaService service)
        {
			_service = service;
        }
		public async Task<IActionResult> Index()
		{
			var allProducers = await _service.GetAllAsync();

			if (allProducers == null)
			{
				return NotFound();
			}

			return View(allProducers);

		}

		//Get: Actors/Create
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([Bind("Logo, Name, Description")] Cinema cinema)
		{
			if (!ModelState.IsValid)
			{
				return NotFound();
			}
			await _service.AddAsync(cinema);
			return RedirectToAction(nameof(Index));

		}



		public async Task<IActionResult> Details(int id)
		{
			var cinema = await _service.GetByIdAsync(id);

			if (cinema == null)
			{
				return NotFound();
			}
			return View(cinema);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var cinema = await _service.GetByIdAsync(id);
			return View(cinema);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("Id, Logo, Name, Description")] Cinema cinema)
		{
			if (!ModelState.IsValid)
			{
				return NotFound();
			}
			await _service.UpdateAsync(id, cinema);
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			var cinema = await _service.GetByIdAsync(id);
			return View(cinema);
		}

		[HttpPost]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var cinema = await _service.GetByIdAsync(id);
			if (cinema == null)
			{
				return NotFound();
			}
			await _service.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
