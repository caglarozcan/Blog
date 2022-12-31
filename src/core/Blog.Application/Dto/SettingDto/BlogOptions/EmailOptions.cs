namespace Blog.Application.Dto.SettingDto.BlogOptions;

public sealed class EmailOptions
{
	public string EmailFrom { get; set; }

	public string EmailHost { get; set; }

	public string EmailPassword { get; set; }

	public int EmailPort { get; set; }
}
