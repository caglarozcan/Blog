using Blog.Application.Response;
using Blog.Application.Services;
using Blog.Application.UnitOfWork;
using Microsoft.AspNetCore.Http;

namespace Blog.Infrastructure.Services
{
	public class FileIOService : IFileIOService
	{
		private IUnitOfWork _unitOfWork { get; }
		private IAuthUserInfoService _authUserInfoService;

		public FileIOService(IUnitOfWork unitOfWork, IAuthUserInfoService authUserInfoService)
		{
			this._unitOfWork = unitOfWork;
			this._authUserInfoService = authUserInfoService;
		}

		#region Info
		/**
		 * 1. Buraya gelen dosya bilgilerinin validation işleminden geçirilmiş olduğu varsayılır.
		 */
		#endregion

		public async Task<Response> Copy(Guid id)
		{
			throw new NotImplementedException();
		}

		public async Task<Response> Create(IFormFile file)
		{
			var mimeTypeWhiteList = await _unitOfWork.MediaTypeReadRepository.GetMediaTypeWhiteListAsync();

			if(mimeTypeWhiteList.Any(m => m.MimeType.Equals(file.ContentType)))
			{
				var fileInfo = mimeTypeWhiteList.FirstOrDefault(m => m.MimeType.Equals(file.ContentType));
				string newFileName = Guid.NewGuid().ToString() + fileInfo.FileExtension;
				await _unitOfWork.MediaWriteRepository.InsertAsync(new Domain.Entities.Media()
				{
					CreatedDate = DateTime.Now,
					Description = "Blog dosyası.",
					MediaTypeId = fileInfo.Id,
					Name = newFileName,
					OriginalName = file.Name,
					UserId = _authUserInfoService.Id
				});

				int status = await _unitOfWork.SaveAsync();

				return new Response("Dosya başarıyla yüklendi.", true);
			}
			else
			{
				return new Response(String.Concat(file.ContentType, " bu türde dosya yüklenemez."), false);
			}
		}

		public async Task<Response> Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		public async Task<Response> Rename(Guid id, string name)
		{
			throw new NotImplementedException();
		}
	}
}
