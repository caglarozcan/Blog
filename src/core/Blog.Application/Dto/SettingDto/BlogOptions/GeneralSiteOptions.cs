namespace Blog.Application.Dto.SettingDto.BlogOptions;

public sealed class GeneralSiteOptions
{
	public required string SiteTitle { get; set; }

	public required string SiteDescription { get; set; }

	public required string SiteUrl { get; set; }

	public required string SiteSlogan { get; set; }
}
