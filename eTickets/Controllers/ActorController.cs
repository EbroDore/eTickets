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
			var a = _service.GetById(id);

			if (a == null)
			{
				return NotFound();
			}
			return View(a);
		}
	}
}
