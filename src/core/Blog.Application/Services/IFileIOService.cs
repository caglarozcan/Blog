using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services
{
	public interface IFileIOService
	{
		Task<string> Create(IFormFile file);

		Task<string> Copy(Guid id);

		Task<string> Rename(Guid id, string name);

		Task<string> Delete(Guid id);
	}
}
