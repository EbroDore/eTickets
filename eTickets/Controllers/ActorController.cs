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
			var actor = await _service.GetAll();

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
		public  IActionResult Create([Bind("FullName, ProfilePictureURL, Bio")] Actor actor)
		{
			if (!ModelState.IsValid)
			{
				return NotFound();
			}
			_service.Add(actor);
			return RedirectToAction(nameof(Index));

		}


		
		public IActionResult Details(int id)
		{
			var actor = _service.GetById(id);

			if (actor == null)
			{
				return NotFound();
			}
			return View(actor);
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var actor = _service.GetById(id);
			return View(actor);
		}

		[HttpPost]
		public IActionResult Edit(int id, [Bind("Id, FullName, ProfilePictureURL, Bio")]Actor actor)
		{
			if (!ModelState.IsValid)
			{
				return NotFound();
			}
			_service.Update(id, actor);
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			var actor = _service.GetById(id);
			return View(actor);
		}

		[HttpPost]
		public IActionResult DeleteConfirmed(int id)
		{
			var actor = _service.GetById(id);
			if(actor == null)
			{
				return NotFound();
			}
			_service.Delete(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
