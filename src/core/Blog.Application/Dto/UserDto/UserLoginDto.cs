using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blog.Application.Dto.UserDto
{
	public class UserLoginDto
	{
		[DisplayName("Email Adresi")]
		[DataType(DataType.EmailAddress)]
		[Required(ErrorMessage = "Email adresi zorunludur.")]
		public string Email { get; set; } = String.Empty;

		[DisplayName("Şifre")]
		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Şifre alanı zorunludur.")]
		public string Password { get; set; } = String.Empty;
	}
}
