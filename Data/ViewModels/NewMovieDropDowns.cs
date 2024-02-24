using eTickets.Models;

namespace eTickets.Data.ViewModels
{
    public class NewMovieDropDowns
    {
        public List<Producer> Producers { get; set; } = new();
        public List<Cinema> Cinemas { get; set; } = new();
        public List<Actor> Actors { get; set; } = new();


    }
}
