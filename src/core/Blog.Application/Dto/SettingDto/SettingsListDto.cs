namespace Blog.Application.Dto.SettingDto
{
	public class SettingsListDto
	{
		public Guid Id { get; set; }

		public Guid SettingGroupId { get; set; }

		public string Name { get; set; }

		public string Value { get; set; }
	}
}
