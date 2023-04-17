using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class Actor
    {
        [Key, Column("ActorId")]
        public int Id { get; set; }

        public string? ProfilePictureURL { get; set; }
        public string? FullName { get; set; }
        public string? Bio { get; set; }


        //Relationships

        public List<Actor_Movie> Actors_Movies { get; set; } = new List<Actor_Movie>();
    }
}
