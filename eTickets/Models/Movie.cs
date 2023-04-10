
using eTickets.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public MovieCategory MovieCategory { get; set; }

        //RelationShips

        public List<Actor_Movie> Actors_Movies { get; set; } = new List<Actor_Movie>();

        //Cinema
        public Cinema? Cinema { get; set; }

        [ForeignKey("CinemaId")]
        public int CinemaId { get; set; }

        //Producer
        public Producer? Producer { get; set; }

        [ForeignKey("ProducerId")]
        public int ProducerId { get; set; }

    }
}
