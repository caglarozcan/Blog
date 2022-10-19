using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Administrator, Editör")]
	public class MediaController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		
		public IActionResult FileUpload()
		{
			return View();
		}

		[HttpPost]
		public IActionResult FileUpload(IFormFile file)
		{
			return Ok();
		}
	}
}
