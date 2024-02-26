using System.ComponentModel.DataAnnotations;

namespace eTickets.Data.ViewModels
{
	public class LoginVM
	{
		[Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address Is Required")]
        public string? EmailAddress { get; set; }

		[Required(ErrorMessage = "Password Is Required")]
		[DataType(DataType.Password)]
		public string? Password { get; set; }
    }
}
