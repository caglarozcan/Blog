using Blog.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Administrator, Editör")]
	public class MediaController : BaseController
	{
		private IMediaService _mediaService;
		private IAuthUserInfoService _authUserInfoService;

		public MediaController(IMediaService mediaService, IAuthUserInfoService authUserInfoService)
		{
			_mediaService = mediaService;
			_authUserInfoService = authUserInfoService;
		}

		public IActionResult Index()
		{
			return View();
		}
		
		public IActionResult FileUpload()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> FileUpload(IFormFile file)
		{
			return Ok(await _mediaService.FileUploadAsync(file));
		}
	}
}
