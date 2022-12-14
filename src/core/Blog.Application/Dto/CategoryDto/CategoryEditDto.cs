using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blog.Application.Dto.CategoryDto;

public class CategoryEditDto
{
	[Required(ErrorMessage = "Kategori Id alanı zorunludur.")]
	public Guid Id { get; set; }

	[DisplayName("Üst Kategori")]
	public Guid? ParentId { get; set; }

	[DataType(DataType.Text)]
	[DisplayName("Kategori Adı")]
	[Required(ErrorMessage = "Kategori adı zorunludur.")]
	[MaxLength(60, ErrorMessage = "Kategori adı en fazla 60 karakter olabilir.")]
	public string Title { get; set; }

	[DataType(DataType.Text)]
	[DisplayName("Icon")]
	[Required(ErrorMessage = "Icon alanı zorunludur.")]
	[MaxLength(20, ErrorMessage = "Icon alanı en fazla 20 karakter olabilir.")]
	public string Icon { get; set; }

	[DataType(DataType.Text)]
	[DisplayName("Renk")]
	[Required(ErrorMessage = "Renk alanı zorunludur.")]
	[MaxLength(20, ErrorMessage = "Renk alanı en fazla 20 karakter olabilir.")]
	public string Color { get; set; }

	[DataType(DataType.MultilineText)]
	[DisplayName("Kısa Kategori Açıklaması")]
	[Required(ErrorMessage = "Kısa kategori açıklaması zorunludur.")]
	[MaxLength(500, ErrorMessage = "Kısa açıklama en fazla 500 karakter olabilir.")]
	public string Description { get; set; }

	[DataType(DataType.Text)]
	[DisplayName("Url (Slug)")]
	[MaxLength(60, ErrorMessage = "Slug alanı en fazla 60 karakter olabilir.")]
	public string? Slug { get; set; }

	[DisplayName("Durum")]
	[Required(ErrorMessage = "Kategori için bir durum seçiniz.")]
	public byte Status { get; set; }
}
