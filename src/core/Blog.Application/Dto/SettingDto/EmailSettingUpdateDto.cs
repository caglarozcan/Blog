using System.ComponentModel.DataAnnotations;

namespace Blog.Application.Dto.SettingDto
{
	public class EmailSettingUpdateDto
	{
		[Required(ErrorMessage = "Email adresi alanı zorunludur.")]
		[EmailAddress(ErrorMessage = "Girilen email adresi geçersizdir.")]
		public string EmailFrom { get; set; }

		[Required(ErrorMessage = "Email sunucusu alanı zorunludur.")]
		public string EmailHost { get; set; }

		[Required(ErrorMessage = "Email şifre alanı zorunludur.")]
		public string EmailPassword { get; set; }

		[Required(ErrorMessage = "Email sunucusu port alanı zorunludur.")]
		[Range(1,999, ErrorMessage = "Girilen port numarası geçersizdir.")]
		public int EmailPort { get; set; }
	}
}
