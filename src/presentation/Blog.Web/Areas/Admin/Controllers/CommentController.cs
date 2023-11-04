using Blog.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Administrator, Editör")]
public class CommentController : BaseController
{
	private readonly ICommentService _commentService;

	public CommentController(ICommentService commentService)
	{
		_commentService = commentService;
	}

	#region Functions
	#region Create

	#endregion

	#region Read
	public async ValueTask<IActionResult> Index()
	{
		return View();
	}
	#endregion

	#region Update

	#endregion

	#region Delete

	#endregion
	#endregion
}
