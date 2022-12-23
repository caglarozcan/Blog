using Blog.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.ViewComponents;

public class GeneralStatisticComponent : ViewComponent
{
	private readonly IDashboardService _dashboardService;

	public GeneralStatisticComponent(IDashboardService dashboardService)
	{
		_dashboardService = dashboardService;
	}

	public async Task<IViewComponentResult> InvokeAsync()
	{
		return View(await _dashboardService.GetGeneralStatisticAsync());
	}
}
