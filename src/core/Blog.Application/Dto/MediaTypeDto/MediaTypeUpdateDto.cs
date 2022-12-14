using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blog.Application.Dto.MediaTypeDto;

public class MediaTypeUpdateDto
{
	[Required(ErrorMessage = "ID alanı zorunludur.")]
	public Guid Id { get; set; }

	[DataType(DataType.Text)]
	[DisplayName("Dosya Tür Adı")]
	[Required(ErrorMessage = "Dosya türü ismi zorunludur.")]
	[MaxLength(50, ErrorMessage = "Dosya tür adı en fazla 50 karakter olabilir.")]
	public string Title { get; set; }

	[DataType(DataType.Text)]
	[DisplayName("Dosya Tipi (MIME Tipi)")]
	[Required(ErrorMessage = "Mime type alanı zorunludur.")]
	[MaxLength(30, ErrorMessage = "Dosya tipi en fazla 30 karakter olabilir.")]
	public string MimeType { get; set; }

	[DataType(DataType.Text)]
	[DisplayName("Dosya Uzantısı")]
	[Required(ErrorMessage = "Dosya uzantısı alanı zorunludur.")]
	[MaxLength(5, ErrorMessage = "Dosya uzantısı en fazla 5 karakter olabilir.")]
	public string FileExtension { get; set; }

	[DataType(DataType.Text)]
	[DisplayName("Dosya Icon'u")]
	[Required(ErrorMessage = "Dosya icon'u alanı zorunludur.")]
	[MaxLength(20, ErrorMessage = "Dosya icon'u en fazla 20 karakter olabilir.")]
	public string Icon { get; set; }

	[DataType(DataType.Text)]
	[DisplayName("Dosya Icon Rengi")]
	[Required(ErrorMessage = "Dosya icon rengi alanı zorunludur.")]
	[MaxLength(10, ErrorMessage = "Dosya icon rengi en fazla 10 karakter olabilir.")]
	public string Color { get; set; }

	[DataType(DataType.Text)]
	[DisplayName("Dosya Yükleme Yolu")]
	[Required(ErrorMessage = "Dosya yükleme yolu alanı zorunludur.")]
	[MaxLength(200, ErrorMessage = "Dosya yükleme yolu en fazla 200 karakter olabilir.")]
	public string UploadDir { get; set; }
}
