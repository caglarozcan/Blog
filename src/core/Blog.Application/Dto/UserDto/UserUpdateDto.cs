using Blog.Application.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blog.Application.Dto.UserDto;

public sealed class UserUpdateDto
{
	[Required(ErrorMessage = "Id alanı dolu olmalıdır.")]
	public Guid Id { get; set; }

	[DisplayName("Kullanıcı Rolü")]
	[DataType(DataType.Text)]
	[Required(ErrorMessage = "Kullanıcı için bir rol seçmelisiniz.")]
	public Guid? RoleId { get; set; }

	[DisplayName("İsim")]
	[DataType(DataType.Text)]
	[Required(ErrorMessage = "İsim alanı zorunludur.")]
	[MaxLength(20, ErrorMessage = "İsim alanı en fazla 20 karakter olabilir.")]
	public required string Name { get; set; }

	[DisplayName("Soyisim")]
	[DataType(DataType.Text)]
	[Required(ErrorMessage = "Soyisim alanı zorunludur.")]
	[MaxLength(20, ErrorMessage = "Soyisim alanı en fazla 20 karakter olabilir.")]
	public required string LastName { get; set; }

	[DisplayName("Takma İsim")]
	[DataType(DataType.Text)]
	[Required(ErrorMessage = "Takma isim alanı zorunludur.")]
	[MaxLength(10, ErrorMessage = "Takma isim alanı en fazla 10 karakter olabilir.")]
	public required string NickName { get; set; }

	[DisplayName("E-posta Adresi")]
	[DataType(DataType.EmailAddress)]
	[Required(ErrorMessage = "Email adresi zorunludur.")]
	[MaxLength(150, ErrorMessage = "Email adresi en fazla 150 karakter olabilir.")]
	public required string Email { get; set; }

	[DisplayName("Şifre")]
	[DataType(DataType.Password)]
	public string? Password { get; set; }

	[DisplayName("Şifre Onay")]
	[DataType(DataType.Password)]
	[Compare(nameof(Password), ErrorMessage = "Şifre tekrarı ile uyuşmuyor.")]
	public string? ConfirmPassword { get; set; }

	[DisplayName("Url")]
	[DataType(DataType.Text)]
	[MaxLength(40, ErrorMessage = "URL alanı en fazla 40 karakter olabilir.")]
	public string? Slug { get; set; }

	[DisplayName("Durum")]
	[Required(ErrorMessage = "Kullanıcı için bir durum seçiniz.")]
	public Status Status { get; set; }

	public bool SendMail { get; set; }
}
