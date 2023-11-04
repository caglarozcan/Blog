using System.ComponentModel.DataAnnotations;

namespace Blog.Application.Dto.SettingDto;

public sealed class EmailSettingUpdateDto
{
	[Required(ErrorMessage = "Email adresi alanı zorunludur.")]
	[EmailAddress(ErrorMessage = "Girilen email adresi geçersizdir.")]
	public required string EmailFrom { get; set; }

	[Required(ErrorMessage = "Email sunucusu alanı zorunludur.")]
	public required string EmailHost { get; set; }

	[Required(ErrorMessage = "Email şifre alanı zorunludur.")]
	public required string EmailPassword { get; set; }

	[Required(ErrorMessage = "Email sunucusu port alanı zorunludur.")]
	[Range(1,999, ErrorMessage = "Girilen port numarası geçersizdir.")]
	public int EmailPort { get; set; }
}
