namespace Blog.Application.Dto.SettingDto
{
	public class BlogOptionsDto
	{
		public string SettingGroupKey { get; set; }

		public List<BlogOptionsSubDto> Options { get; set; }
	}
}
