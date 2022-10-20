using Microsoft.AspNetCore.Http;

namespace Blog.Application.Services
{
	public interface IFileIOService
	{
		Task<Response.Response> Create(IFormFile file);

		Task<Response.Response> Copy(Guid id);

		Task<Response.Response> Rename(Guid id, string name);

		Task<Response.Response> Delete(Guid id);
	}
}
