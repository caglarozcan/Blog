namespace Blog.Application.Dto.SettingDto;

public sealed class SettingsListDto
{
	public Guid Id { get; set; }

	public Guid SettingGroupId { get; set; }

	public required string Name { get; set; }

	public required string Value { get; set; }

	public required string SettingKey { get; set; }
}
