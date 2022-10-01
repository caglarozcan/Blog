using Blog.Application.Dto.UserDto;
using Blog.Application.Request;
using Blog.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Administrator")]
	public class UsersController : Controller
	{
		private IUserService _userService;

		public UsersController(IUserService userService)
		{
			this._userService = userService;
		}

		public IActionResult Index()
		{
			return View();
		}

		#region Create
		public IActionResult Insert()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Insert(UserInsertDto data)
		{
			var result = await _userService.InsertAsync(data, ModelState);

			if (true.Equals(result.Success))
				return Ok(result);

			return new ObjectResult(result.Value != null ? result.Value : result)
			{
				StatusCode = 400
			};
		}
		#endregion

		#region Read
		public async Task<IActionResult> GetList(DataListRequest request)
		{
			var list = await _userService.GetUserListAsync(request);

			return Ok(list);
		}
		#endregion
	}
}
