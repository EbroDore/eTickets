using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
	public class ProducerController : Controller
	{

		private readonly IProducerService _service;

        public ProducerController(IProducerService service)
        {
			_service = service;
        }
        public async Task<IActionResult> Index()
		{
			var allProducers = await _service.GetAllAsync();

			if(allProducers == null)
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
		public async Task<IActionResult> Create([Bind("FullName, ProfilePictureURL, Bio")] Producer producer)
		{
			if (!ModelState.IsValid)
			{
				return NotFound();
			}
			await _service.AddAsync(producer);
			return RedirectToAction(nameof(Index));

		}



		public async Task<IActionResult> Details(int id)
		{
			var actor = await _service.GetByIdAsync(id);

			if (actor == null)
			{
				return NotFound();
			}
			return View(actor);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var producer = await _service.GetByIdAsync(id);
			return View(producer);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("Id, FullName, ProfilePictureURL, Bio")] Producer producer)
		{
			if (!ModelState.IsValid)
			{
				return NotFound();
			}
			await _service.UpdateAsync(id, producer);
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			var producer = await _service.GetByIdAsync(id);
			return View(producer);
		}

		[HttpPost]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var actor = await _service.GetByIdAsync(id);
			if (actor == null)
			{
				return NotFound();
			}
			await _service.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
