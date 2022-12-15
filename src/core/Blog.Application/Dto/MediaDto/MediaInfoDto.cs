using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blog.Application.Dto.MediaDto;

public class MediaInfoDto
{
	[Required(ErrorMessage = "ID alanı zorunludur.")]
	public Guid Id { get; set; }

	[DataType(DataType.Text)]
	[DisplayName("Dosya Adı")]
	public string Name { get; set; }

	[DataType(DataType.Text)]
	[DisplayName("Orijinal Dosya Adı")]
	public string OriginalName { get; set; }

	[DataType(DataType.Text)]
	[DisplayName("Dosya Açıklaması")]
	[Required(ErrorMessage = "Dosya açıklaması alanı zorunludur.")]
	public string Description { get; set; }

	[DataType(DataType.Text)]
	[DisplayName("Dosya MIME Türü")]
	public string MediaTypeName { get; set; }

	[DataType(DataType.Text)]
	[DisplayName("Dosya Uzantısı")]
	public string FileExtension { get; set; }

	[DataType(DataType.DateTime)]
	[DisplayName("Yükleme Tarihi")]
	public DateTime CreatedDate { get; set; }

	[DataType(DataType.DateTime)]
	[DisplayName("Düzenleme Tarihi")]
	public DateTime? UpdateDate { get; set; }

	[DisplayName("Durum")]
	public byte Status { get; set; }
}
