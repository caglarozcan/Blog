﻿using Blog.Application.Dto.MediaTypeDto;
using Blog.Application.Request;
using Blog.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Administrator, Editör")]
	public class MediaTypeController : Controller
	{
		private IMediaTypeService _mediaTypeService;

		public MediaTypeController(IMediaTypeService mediaTypeService)
		{
			_mediaTypeService = mediaTypeService;	
		}

		#region Functions
		#region Create
		[HttpPost]
		public async Task<IActionResult> Insert(MediaTypeInsertDto data)
		{
			var result = await _mediaTypeService.InsertAsync(data, ModelState);

			if (true.Equals(result.Success))
				return Ok(result);

			return new ObjectResult(result.Value != null ? result.Value : result)
			{
				StatusCode = 400
			};
		}
		#endregion

		#region Read
		public async Task<IActionResult> Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> GetList(DataListRequest request)
		{
			var list = await _mediaTypeService.GetMediaTypeListAsync(request);

			return Ok(list);
		}

		[HttpPost]
		public async Task<IActionResult> EditInfo(Guid id)
		{
			var result = await _mediaTypeService.GetUpdatedMediaTypeAsync(id);
			return Ok(result);
		}
		#endregion

		#region Update
		[HttpPost]
		public async Task<IActionResult> StatusChange(Guid id)
		{
			var result = await _mediaTypeService.StatusChangeAsync(id);
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(MediaTypeUpdateDto data)
		{
			var result = await _mediaTypeService.UpdateAsync(data, ModelState);

			if (true.Equals(result.Success))
				return Ok(result);

			return new ObjectResult(result.Value != null ? result.Value : result)
			{
				StatusCode = 400
			};
		}
		#endregion

		#region Delete
		public async Task<IActionResult> Delete(Guid id)
		{
			var result = await _mediaTypeService.DeleteAsync(id);
			return Ok(result);
		}
		#endregion
		#endregion
	}
}
