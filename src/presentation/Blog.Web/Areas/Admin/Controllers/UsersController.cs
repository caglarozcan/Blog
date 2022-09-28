using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Administrator")]
	public class UsersController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Insert()
		{
			return View();
		}
	}
}
