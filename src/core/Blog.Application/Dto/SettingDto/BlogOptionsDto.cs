namespace Blog.Application.Dto.SettingDto;

public record BlogOptionsDto
{
	#region GeneralSiteSettings
	public string SiteTitle { get; set; }

	public string SiteDescription { get; set; }

	public string SiteUrl { get; set; }

	public string SiteSlogan { get; set; }
	#endregion

	#region EmailSettings
	public string EmailFrom { get; set; }

	public string EmailHost { get; set; }

	public string EmailPassword { get; set; }

	public int EmailPort { get; set; }
	#endregion

	#region FileUploadSettings
	public string UploadPath { get; set; }

	public string UploadDirType { get; set; }

	public int ImageSmallWidth { get; set; }

	public int ImageSmallHeight { get; set; }

	public int ImageMediumWidth { get; set; }

	public int ImageMediumHeight { get; set; }

	public int ImageLargeWidth { get; set; }

	public int ImageLargeHeight { get; set; }
	#endregion

	#region CommentSettings
	public bool IsShowComment { get; set; }

	public bool IsApproveComment { get; set; }
	#endregion

	#region ArticleSettings
	public Guid DefaultCategoryId { get; set; }
	#endregion

	#region PagingSettings
	public int UserPagingSize { get; set; }

	public int AdminPagingSize { get; set; }
	#endregion
}
