using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
	public class MovieService : EntityBaseRepository<Movie>, IMovieService
	{
		private readonly ApplicationDbContext _context;
		public MovieService(ApplicationDbContext context) : base(context) 
		{
			_context = context;
		}

		public async Task<Movie> GetMovieByIdAsync(int id)
		{
			var movie = await _context.Movies
				.Include(c => c.Cinema)
				.Include(p => p.Producer)
				.Include(am => am.Actors_Movies)
				.ThenInclude(a => a.Actor)
				.FirstOrDefaultAsync(n => n.Id == id);
			return movie;
		}
	}
}
