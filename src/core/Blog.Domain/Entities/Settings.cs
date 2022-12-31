namespace Blog.Domain.Entities;

public class Settings : BaseEntity
{
	public Guid SettingGroupId { get; set; }

	public string Name { get; set; }

	public string Value { get; set; }

	public string SettingKey { get; set; }

	public virtual SettingGroup SettingGroup { get; set; }
}
