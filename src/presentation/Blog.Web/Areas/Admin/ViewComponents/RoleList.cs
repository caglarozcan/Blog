using Blog.Application.Dto.RoleDto;
using Blog.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.ViewComponents;

public class RoleList : ViewComponent
{
	private readonly IRoleService _roleService;

	public RoleList(IRoleService roleService)
	{
		_roleService = roleService;
	}

	public async Task<IViewComponentResult> InvokeAsync(Guid? id)
	{
		var items = await GetItemsAsync(id);
		return View(items);
	}

	private async Task<RoleSelectDto> GetItemsAsync(Guid? id)
	{
		return await _roleService.GetSelectRolesAsync(id);
	}
}
