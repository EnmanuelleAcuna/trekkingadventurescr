using System.ComponentModel.DataAnnotations;

namespace trekkingadventurescr.Models.ViewModels
{
	public class LogInViewModel
	{
		[Required]
		[Display(Name = "Username")]
		public string username { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string password { get; set; }
	}
}