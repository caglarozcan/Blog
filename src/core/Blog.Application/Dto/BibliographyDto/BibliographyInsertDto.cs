using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Blog.Application.Dto.BibliographyDto;

public class BibliographyInsertDto
{
	[DataType(DataType.Text)]
	[DisplayName("Kaynakça Adı")]
	[Required(ErrorMessage = "Kaynakça adı zorunludur.")]
	[MaxLength(200, ErrorMessage = "Kaynakça adı en fazla 200 karakter olabilir.")]
	public string Title { get; set; }

	[DataType(DataType.Text)]
	[DisplayName("Bağlantı Adresi")]
	[Required(ErrorMessage = "Bağlantı adresi zorunludur.")]
	[MaxLength(200, ErrorMessage = "Bağlantı adresi en fazla 500 karakter olabilir.")]
	public string Url { get; set; }

	[DisplayName("Durum")]
	[Required(ErrorMessage = "Kaynakça için bir durum seçiniz.")]
	public byte Status { get; set; }
}
