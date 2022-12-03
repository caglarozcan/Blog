using System.ComponentModel.DataAnnotations;

namespace Blog.Application.Dto.SettingDto
{
	public class PagingSettingUpdateDto
	{
		[Required(ErrorMessage = "Kullanıcı sayfalama boyutu alanı zorunludur.")]
		public int UserPagingSize { get; set; }

		[Required(ErrorMessage = "Yönetici sayfalama boyutu alanı zorunludur.")]
		public int AdminPagingSize { get; set; }
	}
}
