using Blog.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Administrator")]
	public class SettingController : Controller
	{
		private ISettingService _settingService;

		public SettingController(ISettingService settingService)
		{
			_settingService = settingService;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _settingService.GetSettingsAsync());
		}
	}
}
