using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Data.Services
{
	public class ActorService : IActorService
	{
		private readonly ApplicationDbContext _context;
		public ActorService(ApplicationDbContext context)
		{
			_context = context;
		}
		public void Add(Actor actor)
		{
			_context.Actors.Add(actor);
			_context.SaveChanges();

		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Actor>> GetAll()
		{
			var result = await _context.Actors.ToListAsync();
			return result;
		}

		public  Actor GetById(int id)
		{
			var actor =  _context.Actors.FirstOrDefault(p => p.Id == id);
			return actor;
		}

		public Actor Update(int id, Actor newActor)
		{
			throw new NotImplementedException();
		}
	}
}
