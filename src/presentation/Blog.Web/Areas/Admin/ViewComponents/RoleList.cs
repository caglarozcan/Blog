using Blog.Application.Dto.RoleDto;
using Blog.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.ViewComponents
{
	public class RoleList : ViewComponent
	{
		private readonly IRoleService _roleService;

		public RoleList(IRoleService roleService)
		{
			_roleService = roleService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var items = await GetItemsAsync();
			return View(items);
		}

		private Task<List<RoleSelectDto>> GetItemsAsync()
		{
			return _roleService.GetSelectRolesAsync();
		}
	}
}
