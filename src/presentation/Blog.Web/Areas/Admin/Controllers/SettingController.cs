using Blog.Application.Dto.SettingDto;
using Blog.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Administrator")]
public class SettingController : BaseController
{
	private ISettingService _settingService;

	public SettingController(ISettingService settingService)
	{
		_settingService = settingService;
	}

	#region Create

	#endregion

	#region Read
	public async Task<IActionResult> Index()
	{
		var settings = await _settingService.GetSettingsAsync();
		return View(settings);
	}
    #endregion

    #region Upate
    /// <summary>
    /// Update işlemi için kullanılan modellerin özellikleri Settings tablosundaki SettingKey ile aynı olmak zorunda.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    [HttpPost]
	public async Task<IActionResult> SaveGeneralSettings(GeneralSettingUpdateDto data)
	{
		var result = await _settingService.SaveGeneralSettingsAsync(data, ModelState);

		if (true.Equals(result.Success))
			return Ok(result);

		return new ObjectResult(result.Value != null ? result.Value : result)
		{
			StatusCode = 400
		};
	}

	[HttpPost]
	public async Task<IActionResult> SaveArticleSettings(ArticleSettingUpdateDto data)
	{
		var result = await _settingService.SaveArticleSettingsAsync(data, ModelState);

		if (true.Equals(result.Success))
			return Ok(result);

		return new ObjectResult(result.Value != null ? result.Value : result)
		{
			StatusCode = 400
		};
	}

	[HttpPost]
	public async Task<IActionResult> SaveFileUploadSettings(FileUploadSettingUpdateDto data)
	{
		var result = await _settingService.SaveFileUploadSettingsAsync(data, ModelState);

		if (true.Equals(result.Success))
			return Ok(result);

		return new ObjectResult(result.Value != null ? result.Value : result)
		{
			StatusCode = 400
		};
	}

	[HttpPost]
	public async Task<IActionResult> SaveMailSettings(EmailSettingUpdateDto data)
	{
		var result = await _settingService.SaveMailSettingsAsync(data, ModelState);

		if (true.Equals(result.Success))
			return Ok(result);

		return new ObjectResult(result.Value != null ? result.Value : result)
		{
			StatusCode = 400
		};
	}

	[HttpPost]
	public async Task<IActionResult> SaveCommentSettings(CommentSettingUpdateDto data)
	{
		var result = await _settingService.SaveCommentSettingsAsync(data, ModelState);

		if (true.Equals(result.Success))
			return Ok(result);

		return new ObjectResult(result.Value != null ? result.Value : result)
		{
			StatusCode = 400
		};
	}

	[HttpPost]
	public async Task<IActionResult> SavePagingSettings(PagingSettingUpdateDto data)
	{
		var result = await _settingService.SavePagingSettingsAsync(data, ModelState);

		if (true.Equals(result.Success))
			return Ok(result);

		return new ObjectResult(result.Value != null ? result.Value : result)
		{
			StatusCode = 400
		};
	}
	#endregion

	#region Delete

	#endregion
}
