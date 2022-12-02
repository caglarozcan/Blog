namespace Blog.Application.Dto.SettingDto
{
	public class SettingGroupListDto
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string SettingGroupKey { get; set; }

		public List<SettingsListDto> Settings { get; set; }
	}
}
