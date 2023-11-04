using Microsoft.AspNetCore.Http;

namespace Blog.Application.Services;

public interface IFileIOService
{
	ValueTask<Response.Response> Create(IFormFile file);

	ValueTask<Response.Response> Copy(Guid id);

	ValueTask<Response.Response> Rename(Guid id, string name);

	ValueTask<Response.Response> Delete(Guid id);
}
