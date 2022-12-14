using System.ComponentModel.DataAnnotations;

namespace Blog.Application.Dto.SettingDto;

public class FileUploadSettingUpdateDto
{
	[Required(ErrorMessage = "Medya yükleme dizini alanı zorunludur.")]
	public string UploadPath { get; set; }

	public bool UploadDirType { get; set; }

	[Required(ErrorMessage = "Küçük resim genişliği alanı zorunludur.")]
	public int ImageSmallWidth { get; set; }

	[Required(ErrorMessage = "Küçük resim yüksekliği alanı zorunludur.")]
	public int ImageSmallHeight { get; set; }

	[Required(ErrorMessage = "Orta resim genişliği alanı zorunludur.")]
	public int ImageMediumWidth { get; set; }

	[Required(ErrorMessage = "Orta resim yüksekliği alanı zorunludur.")]
	public int ImageMediumHeight { get; set; }

	[Required(ErrorMessage = "Büyük resim genişliği alanı zorunludur.")]
	public int ImageLargeWidth { get; set; }

	[Required(ErrorMessage = "Büyük resim yüksekliği alanı zorunludur.")]
	public int ImageLargeHeight { get; set; }
}
