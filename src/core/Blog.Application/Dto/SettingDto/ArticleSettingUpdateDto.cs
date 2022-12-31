using System.ComponentModel.DataAnnotations;

namespace Blog.Application.Dto.SettingDto;

public sealed class ArticleSettingUpdateDto
{
	[Required(ErrorMessage = "Varsayılan kategori seçilmesi zorunludur.")]
	public Guid DefaultCategoryId { get; set; }
}
