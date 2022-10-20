using Microsoft.AspNetCore.Http;

namespace Blog.Application.Services
{
	public interface IMediaService
	{
		Task<Response.Response> FileUploadAsync(IFormFile file);
	}
}
