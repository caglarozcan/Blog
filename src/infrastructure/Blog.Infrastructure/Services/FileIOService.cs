using Blog.Application.Response;
using Blog.Application.Services;
using Blog.Application.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace Blog.Infrastructure.Services;

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
		//TODO : Yüklenen dosya resimse appsettingsten okunan değerler ile resimleri boyutlandır ve farklı klasörler içerisine at.
		//TODO : Dosya yükleme dizininde sadece okuma yazma izni olacak. Çalıştırma izni olmayacak.

		if (file.Length > 0)
		{
			var mimeTypeWhiteList = await _unitOfWork.MediaTypeReadRepository.GetMediaTypeWhiteListAsync();

			if (mimeTypeWhiteList.Any(m => m.MimeType.Equals(file.ContentType)))
			{
				var fileInfo = mimeTypeWhiteList.FirstOrDefault(m => m.MimeType.Equals(file.ContentType));
				string newFileName = String.Concat(Guid.NewGuid().ToString(), fileInfo.FileExtension);

				//string uploadPath = @"C:\Users\caglar.ozcan\source\Workspaces\Blog\src\presentation\Blog.Web\Uploads\" + fileInfo.UploadDir.Replace("/", "\\") + @"\" + newFileName;
				string uploadPath = @"D:\Projects\Visualstudio\Blog\src\presentation\Blog.Web\wwwroot\Uploads\" + fileInfo.UploadDir.Replace("/", "\\") + @"\" + newFileName;

				using (var stream = System.IO.File.Create(uploadPath))
				{
					await file.CopyToAsync(stream);
				}

				await _unitOfWork.MediaWriteRepository.InsertAsync(new Domain.Entities.Media()
				{
					CreatedDate = DateTime.Now,
					Description = "Blog dosyası.",
					MediaTypeId = fileInfo.Id,
					Name = newFileName,
					OriginalName = file.FileName,
					UserId = _authUserInfoService.Id
				});

				await _unitOfWork.SaveAsync();

				return new Response("Dosya başarıyla yüklendi.", true);
			}
			else
			{
				return new Response(String.Concat(file.ContentType, " bu türde dosya yüklenemez."), false);
			}
		}
		else
		{
			return new Response("Dosya seçmelisiniz.", false);
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
