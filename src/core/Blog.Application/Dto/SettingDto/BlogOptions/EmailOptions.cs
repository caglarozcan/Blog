namespace Blog.Application.Dto.SettingDto.BlogOptions;

public sealed class EmailOptions
{
	public required string EmailFrom { get; set; }

	public required string EmailHost { get; set; }

	public required string EmailPassword { get; set; }

	public int EmailPort { get; set; }
}
