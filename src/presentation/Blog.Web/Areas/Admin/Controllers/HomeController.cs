using Blog.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Administrator, Editör")]
public class HomeController : Controller
{
	private readonly IDashboardService _dashboardService;

	public HomeController(IDashboardService dashboardService)
	{
		_dashboardService = dashboardService;
	}

	public IActionResult Index()
	{
		return View();
	}

	public async ValueTask<IActionResult> GeneralStatistic()
	{
		return View(await _dashboardService.GetGeneralStatisticAsync());
	}
}
