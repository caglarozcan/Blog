using Blog.Application.Dto.MediaTypeDto;
using Blog.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.ViewComponents
{
	public class MediaTypeSelect : ViewComponent
	{
		private readonly IMediaTypeService _mediaTypeService;

		public MediaTypeSelect(IMediaTypeService mediaTypeService)
		{
			_mediaTypeService = mediaTypeService;
		}

		public async Task<IViewComponentResult> InvokeAsync(Guid? id)
		{
			var items = await GetItemsAsync(id);
			return View(items);
		}

		private Task<MediaTypeSelectDto> GetItemsAsync(Guid? id)
		{
			return _mediaTypeService.GetMediaTypeSelectAsync(id);
		}
	}
}
