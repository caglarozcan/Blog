﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Blog.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Administrator, Editör")]
	public class ArticleController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Insert()
		{
			return View();
		}

		public IActionResult Series()
		{
			return View();
		}
	}
}
