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

		#region Functions
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
		public async Task<IActionResult> Index()
		{
			return View();
		}

		public async Task<IActionResult> GetList(DataListRequest request)
		{
			var list = await _userService.GetUserListAsync(request);

			return Ok(list);
		}
		#endregion

		#region Update
		public async Task<IActionResult> Update(Guid id)
		{
			var user = await _userService.GetUpdatedUserAsync(id);
			return View(user);
		}

		[HttpPost]
		public async Task<IActionResult> Update(UserUpdateDto data)
		{
			var result = await _userService.UpdateAsync(data, ModelState);

			if (true.Equals(result.Success))
				return Ok(result);

			return new ObjectResult(result.Value != null ? result.Value : result)
			{
				StatusCode = 400
			};
		}

		[HttpPost]
		public async Task<IActionResult> StatusChange(Guid id)
		{
			var result = await _userService.StatusChangeAsync(id);
			return Ok(result);
		}
		#endregion

		#region Delete
		[HttpPost]
		public async Task<IActionResult> Delete(Guid id)
		{
			var result = await _userService.DeleteAsync(id);
			return Ok(result);
		}
		#endregion
		#endregion
	}
}
