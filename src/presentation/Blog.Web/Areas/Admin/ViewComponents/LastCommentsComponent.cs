using Blog.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.ViewComponents;

public class LastCommentsComponent : ViewComponent
{
	private readonly IDashboardService _dashboardService;

	public LastCommentsComponent(IDashboardService dashboardService)
	{
		_dashboardService = dashboardService;
	}

	public async Task<IViewComponentResult> InvokeAsync()
	{
		return View();
	}
}