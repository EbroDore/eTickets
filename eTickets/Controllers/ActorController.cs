using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
	public class ActorController : Controller
	{
		private readonly IActorService _service;

		public ActorController(IActorService service)
		{
			_service = service;
		}
		public async Task<IActionResult> Index()
		{
			var actor = await _service.GetAllAsync();

			if (actor == null)
			{
				return NotFound();
			}

			return View(actor);
		}

		//Get: Actors/Create
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public  async Task<IActionResult> Create([Bind("FullName, ProfilePictureURL, Bio")] Actor actor)
		{
			if (!ModelState.IsValid)
			{
				return NotFound();
			}
			await _service.AddAsync(actor);
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
			var actor = await _service.GetByIdAsync(id);
			return View(actor);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("Id, FullName, ProfilePictureURL, Bio")]Actor actor)
		{
			if (!ModelState.IsValid)
			{
				return NotFound();
			}
			await _service.UpdateAsync(id, actor);
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			var actor = await _service.GetByIdAsync(id);
			return View(actor);
		}

		[HttpPost]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var actor = await _service.GetByIdAsync(id);
			if(actor == null)
			{
				return NotFound();
			}
			await _service.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
