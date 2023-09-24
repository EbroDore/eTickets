using eTickets.Data.Base;
using eTickets.Data.ViewModels;
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

        public async Task AddNewMovieAsync(NewMovieVM data)
        {
			var newMovie = new Movie()
			{
				Name = data.Name,
				Description = data.Description,
				Price = data.Price,
				CinemaId = data.CinemaId,
				ImageURL = data.ImageURL,
				StartDate = data.StartDate,
				EndDate = data.EndDate,
				MovieCategory = data.MovieCategory,
				ProducerId = data.ProducerId
			};
			await _context.Movies.AddAsync(newMovie);
			await _context.SaveChangesAsync();

			// Add Movie Actors
			foreach(var actorId in data.ActorIds)
			{
				var newActorMovie = new Actor_Movie()
				{
					MovieId = newMovie.Id,
					ActorId = actorId
				};
				await _context.Actors_Movies.AddAsync(newActorMovie);
			}
				await _context.SaveChangesAsync();
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

        public async Task<NewMovieDropDowns> GetNewMovieDropDownsValues()
        {
			var response = new NewMovieDropDowns()
			{
				Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;

        }
    }
}
