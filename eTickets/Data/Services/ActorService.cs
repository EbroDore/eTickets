using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using eTickets.Data.Base;

namespace eTickets.Data.Services
{
    public class ActorService : EntityBaseRepository<Actor>, IActorService
	{
		public ActorService(ApplicationDbContext context) :base(context) { }
	
		
	}
}
