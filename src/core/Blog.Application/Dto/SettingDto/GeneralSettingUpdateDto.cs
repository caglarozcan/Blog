﻿using System.ComponentModel.DataAnnotations;

namespace Blog.Application.Dto.SettingDto;

public sealed class GeneralSettingUpdateDto
{
	[Required(ErrorMessage = "Sita başlığı alanı zorunludur.")]
	[MaxLength(ErrorMessage = "Site başlığı en fazla 250 karakter olabilir.")]
	public required string SiteTitle { get; set; }

	[Required(ErrorMessage = "Sita açıklaması alanı zorunludur.")]
	[MaxLength(ErrorMessage = "Site açıklaması en fazla 250 karakter olabilir.")]
	public required string SiteDescription { get; set; }

	[Required(ErrorMessage = "Site url alanı zorunludur.")]
	[MaxLength(ErrorMessage = "Site url alanı en fazla 250 karakter olabilir.")]
	public required string SiteUrl { get; set; }

	[Required(ErrorMessage = "Site slogan alanı zorunludur.")]
	[MaxLength(ErrorMessage = "Site sloganı en fazla 250 karakter olabilir.")]
	public required string SiteSlogan { get; set; }
}
