using Blog.Application.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blog.Application.Dto.ArticleDto
{
	public sealed class ArticleInsertDto
	{
		[DataType(DataType.Text)]
		[DisplayName("Makale Başlığı")]
		[Required(ErrorMessage = "Makale başlığı zorunludur.")]
		public required string Title { get; set; }

		[DataType(DataType.Text)]
		[DisplayName("Makale İçeriği")]
		[Required(ErrorMessage = "Makale içeriği zorunludur.")]
		public required string Content { get; set; }

		[DataType(DataType.MultilineText)]
		[DisplayName("Makale Açıklaması")]
		public string? Description { get; set; } = default;

		[DataType(DataType.Text)]
		[DisplayName("Makale URL")]
		public string? Slug { get; set; } = default;

		[DataType(DataType.Text)]
		[DisplayName("Makale kategorileri")]
		[Required(ErrorMessage = "En az bir tane kategori seçmelisiniz.")]
		public required List<Guid> Categories { get; set; }

		[DataType(DataType.Text)]
		[DisplayName("Kayıt Türü")]
		[Required(ErrorMessage = "Makale kayıt türü seçilmedi.")]
		public ArticleSaveType SaveType { get; set; }
	}
}
