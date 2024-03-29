﻿namespace Blog.Application.Dto.SettingDto.BlogOptions;

public sealed class FileUploadOptions
{
	public required string UploadPath { get; set; }

	public required string UploadDirType { get; set; }

	public int ImageSmallWidth { get; set; }

	public int ImageSmallHeight { get; set; }

	public int ImageMediumWidth { get; set; }

	public int ImageMediumHeight { get; set; }

	public int ImageLargeWidth { get; set; }

	public int ImageLargeHeight { get; set; }

	public bool ThumbIsRatioResize { get; set; }

	public bool MediumIsRatioResize { get; set; }

	public bool LargeIsRatioResize { get; set; }
}
