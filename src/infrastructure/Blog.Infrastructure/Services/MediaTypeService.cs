using Blog.Application.Dto.MediaTypeDto;
using Blog.Application.Enums;
using Blog.Application.Request;
using Blog.Application.Response;
using Blog.Application.Services;
using Blog.Application.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blog.Infrastructure.Services;

public class MediaTypeService : BaseService, IMediaTypeService
{
	private readonly IUnitOfWork _unitOfWork;

	public MediaTypeService(IUnitOfWork unitOfWork)
	{
		this._unitOfWork = unitOfWork;
	}

	#region Functions
	#region Create
	public async ValueTask<Response<ProblemDetails>> InsertAsync(MediaTypeInsertDto data, ModelStateDictionary modelState)
	{
		if (!modelState.IsValid)
		{
			return new Response<ProblemDetails>(message: "Doğrulama hatası", success: false, ModelValidationProblem(modelState, "Formda gönderilen alanlar geçersiz veya eksik."));
		}

		if (await _unitOfWork.MediaTypeReadRepository.AnyAsync(c => c.Title.Equals(data.Title.Trim()) || c.MimeType.Equals(data.MimeType) || c.FileExtension.Equals(data.FileExtension)))
		{
			return new Response<ProblemDetails>(message: "Aynı isimde medya türü sistemde zaten tanımlı.", success: false);
		}
		else
		{
			await _unitOfWork.MediaTypeWriteRepository.InsertAsync(new Domain.Entities.MediaType()
			{
				Title = data.Title,
				MimeType = data.MimeType,
				FileExtension = data.FileExtension,
				UploadDir = data.UploadDir,
				Icon = data.Icon,
				Color = data.Color,
				CreatedDate = DateTime.Now,
				Status = (byte)Status.Active
			});

			int result = await _unitOfWork.SaveAsync();

			if (result == 1)
			{
				return new Response<ProblemDetails>(message: "Medya türü başarıyla eklendi.", success: true);
			}
			else
			{
				return new Response<ProblemDetails>(message: "Medya türü ekleme sırasında bir hata oluştu. Daha sonra tekrar deneyiniz.", success: false);
			}
		}
	}
	#endregion

	#region Read
	public async ValueTask<PagingDataResponse<MediaTypeListDto>> GetMediaTypeListAsync(DataListRequest request)
	{
		return await _unitOfWork.MediaTypeReadRepository.GetMediaTypeListAsync(request);
	}

	public async ValueTask<Response<MediaTypeUpdateDto>> GetUpdatedMediaTypeAsync(Guid id)
	{
		var mediaType = await _unitOfWork.MediaTypeReadRepository.GetAsync(m => m.Id.Equals(id));

		if (mediaType == null)
			return new Response<MediaTypeUpdateDto>("İşlem yapmak istediğiniz medya türü sistemde bulunamadı.", false);

		return new Response<MediaTypeUpdateDto>("", true, new MediaTypeUpdateDto()
		{
			Id = mediaType.Id,
			Title = mediaType.Title,
			FileExtension = mediaType.FileExtension,
			MimeType = mediaType.MimeType,
			UploadDir = mediaType.UploadDir,
			Icon = mediaType.Icon,
			Color = mediaType.Color
		});
	}

	public async ValueTask<MediaTypeSelectDto> GetMediaTypeSelectAsync(Guid? id)
	{
		return await _unitOfWork.MediaTypeReadRepository.GetMediaTypeSelectAsync(id);
	}
	#endregion

	#region Update
	public async ValueTask<Response> StatusChangeAsync(Guid id)
	{
		var mediaType = await _unitOfWork.MediaTypeReadRepository.GetAsync(m => m.Id.Equals(id));

		if (mediaType == null)
			return new Response("İşlem yapmak istediğiniz medya türü sistemde bulunamadı.", false);

		mediaType.Status = (byte)(mediaType.Status == 1 ? Status.Passive : Status.Active);

		await _unitOfWork.MediaTypeWriteRepository.UpdateAsync(mediaType);
		int result = await _unitOfWork.SaveAsync();

		if (!result.Equals(1))
			return new Response("Medya türü durumu değiştirme sırasında bir hata oluştu. Daha sonra tekrar deneyiniz.", false);

		return new Response("Medya türü durumu değiştirilmiştir.", true);
	}

	public async ValueTask<Response<ProblemDetails>> UpdateAsync(MediaTypeUpdateDto data, ModelStateDictionary modelState)
	{
		if (!modelState.IsValid)
		{
			return new Response<ProblemDetails>(message: "Doğrulama hatası", success: false, ModelValidationProblem(modelState, "Formda gönderilen alanlar geçersiz veya eksik."));
		}

		if (await _unitOfWork.MediaTypeReadRepository.AnyAsync(c => (c.Title.Equals(data.Title.Trim()) || c.MimeType.Equals(data.MimeType) || c.FileExtension.Equals(data.FileExtension)) && !c.Id.Equals(data.Id)))
		{
			return new Response<ProblemDetails>(message: "Aynı isimde medya türü sistemde zaten tanımlı.", success: false);
		}
		else
		{
			var mediaType = await _unitOfWork.MediaTypeReadRepository.GetAsync(m => m.Id.Equals(data.Id));

			if (mediaType == null)
			{
				return new Response<ProblemDetails>("İşlem yapmak istediğiniz medya türü sistemde bulunamadı.", false);
			}
			else
			{
				mediaType.Title = data.Title;
				mediaType.MimeType = data.MimeType;
				mediaType.FileExtension = data.FileExtension;
				mediaType.UploadDir = data.UploadDir;
				mediaType.Icon = data.Icon;
				mediaType.Color = data.Color;
				mediaType.UpdatedDate = DateTime.Now;

				await _unitOfWork.MediaTypeWriteRepository.UpdateAsync(mediaType);
				int result = await _unitOfWork.SaveAsync();

				if (result == 1)
				{
					return new Response<ProblemDetails>(message: "Medya türü başarıyla güncellendi.", success: true);
				}
				else
				{
					return new Response<ProblemDetails>(message: "Medya türü güncelleme sırasında bir hata oluştu. Daha sonra tekrar deneyiniz.", success: false);
				}
			}
		}
	}
	#endregion

	#region Delete
	public async ValueTask<Response> DeleteAsync(Guid id)
	{
		var mediaType = await _unitOfWork.MediaTypeReadRepository.GetAsync(m => m.Id.Equals(id));

		if (mediaType == null)
			return new Response("Silmek istediğiniz medya türü sistemde bulunamadı.", false);

		await _unitOfWork.MediaTypeWriteRepository.DeleteAsync(mediaType);

		int result = await _unitOfWork.SaveAsync();

		if (!result.Equals(1))
			return new Response("Medya türü silinirken bir hata oluştu. Daha sonra tekrar deneyiniz.", true);

		return new Response("Medya türü balşarıyla silinmiştir.", true);
	}
	#endregion
	#endregion
}
