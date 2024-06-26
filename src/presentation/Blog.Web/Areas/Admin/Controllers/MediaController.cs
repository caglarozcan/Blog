﻿using Blog.Application.Request;
using Blog.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Administrator, Editör")]
public class MediaController : BaseController
{
	private IMediaService _mediaService;

	public MediaController(IMediaService mediaService)
	{
		_mediaService = mediaService;
	}

	#region Functions
	#region Create
	[HttpPost]
	public async ValueTask<IActionResult> FileUpload(IFormFile file)
	{
		return Ok(await _mediaService.FileUploadAsync(file));
	}
	#endregion

	#region Read
	public IActionResult Index()
	{
		return View();
	}

	public IActionResult FileUpload()
	{
		return View();
	}

	[HttpGet]
	public async ValueTask<IActionResult> EditInfo(Guid id)
	{
		return Ok(await _mediaService.GetMediaInfoAsync(id));
	}

	[HttpPost]
	public async ValueTask<IActionResult> GetMediaList(DataListRequest request)
	{
		return Ok(await _mediaService.GetMediaListAsync(request));
	}

	[HttpPost]
	public async ValueTask<IActionResult> GetFilteredMediaList(DataListRequest request)
	{
		return Ok(await _mediaService.GetFilteredMediaListAsync(request));
	}
	#endregion

	#region Update

	#endregion

	#region Delete

	#endregion
	#endregion
}
