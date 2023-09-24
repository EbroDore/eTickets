
using eTickets.Data.Base;
using eTickets.Data.Enums;
using eTickets.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Data.ViewModels
{
    public class NewMovieVM
    {

        [Display(Name = "Movie Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

		[Display(Name = "Movie Description")]
		[Required(ErrorMessage = "Description is required")]
		public string? Description { get; set; }

		[Display(Name = "Movie Price")]
		[Required(ErrorMessage = "Price is required")]
		public double Price { get; set; }

		[Display(Name = "Movie ImageURL")]
		[Required(ErrorMessage = "ImageURL is required")]
		public string ImageURL { get; set; }

		[Display(Name = "Movie StartDate")]
		[Required(ErrorMessage = "StartDate is required")]
		public DateTime StartDate { get; set; }

		[Display(Name = "Movie EndDate")]
		[Required(ErrorMessage = "EndDate is required")]
		public DateTime EndDate { get; set; }


		[Display(Name = "Select a Category")]
		[Required(ErrorMessage = "Movie Category is required")]
		public MovieCategory MovieCategory { get; set; }

		//RelationShips

		[Display(Name = "Select Actor")]
		[Required(ErrorMessage = "Actor is required")]
		public List<int>? ActorIds { get; set; }

		[Display(Name = "Select Cinema")]
		[Required(ErrorMessage = "Cinema is required")]
		public int CinemaId { get; set; }

		[Display(Name = "Select Producer")]
		[Required(ErrorMessage = "Producer is required")]
		public int ProducerId { get; set; }




    }
}
