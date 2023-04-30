using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class Actor : IEntityBase
    {
        [Key, Column("ActorId")]
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string? ProfilePictureURL { get; set; }

		[Display(Name = "Full Name")]
		[Required(ErrorMessage = "Full Name is required")]

		public string? FullName { get; set; }

		[Display(Name = "Biography")]
		[Required(ErrorMessage = "Bio is required")]

		public string? Bio { get; set; }


        //Relationships

        public List<Actor_Movie> Actors_Movies { get; set; } = new List<Actor_Movie>();
    }
}
