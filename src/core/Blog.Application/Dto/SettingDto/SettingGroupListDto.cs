namespace Blog.Application.Dto.SettingDto;

public sealed class SettingGroupListDto
{
	public Guid Id { get; set; }

	public required string Name { get; set; }

	public required string Description { get; set; }

	public required string SettingGroupKey { get; set; }

	public List<SettingsListDto>? Settings { get; set; }
}
