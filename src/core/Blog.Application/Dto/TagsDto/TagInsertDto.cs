using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blog.Application.Dto.TagsDto
{
	public class TagInsertDto
	{
		[DataType(DataType.Text)]
		[DisplayName("Etiket İsmi")]
		[Required(ErrorMessage = "Etiket ismi zorunludur.")]
		[MaxLength(20, ErrorMessage = "Etiket ismi en fazla 20 karakter olabilir.")]
		public string Title { get; set; }

		[DataType(DataType.Text)]
		[DisplayName("URL (Slug)")]
		[MaxLength(20, ErrorMessage = "Etiket Slug değeri en fazla 20 karakter olabilir.")]
		public string? Slug { get; set; }

		[DisplayName("Durum")]
		[Required(ErrorMessage = "Kategori için bir durum seçiniz.")]
		public byte Status { get; set; }
	}
}
