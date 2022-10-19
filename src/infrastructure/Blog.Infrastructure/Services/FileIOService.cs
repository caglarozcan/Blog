using Blog.Application.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Services
{
	public class FileIOService : IFileIOService
	{
		public async Task<string> Copy(Guid id)
		{
			throw new NotImplementedException();
		}

		public async Task<string> Create(IFormFile file)
		{
			throw new NotImplementedException();
		}

		public async Task<string> Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		public async Task<string> Rename(Guid id, string name)
		{
			throw new NotImplementedException();
		}
	}
}
