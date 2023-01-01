using Blog.Application.Dto.BibliographyDto;
using Blog.Application.Request;
using Blog.Application.Response;
using Blog.Application.Services;
using Blog.Application.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blog.Infrastructure.Services;

public class BibliographyService : BaseService, IBibliographyService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IAuthUserInfoService _authUserInfoService;

	public BibliographyService(IUnitOfWork unitOfWork, IAuthUserInfoService authUserInfoService)
	{
		_unitOfWork = unitOfWork;
		_authUserInfoService = authUserInfoService;
	}

	#region Functions
	#region Create
	public async Task<Response<ProblemDetails>> InsertAsync(BibliographyInsertDto data, ModelStateDictionary modelState)
	{
		if (!modelState.IsValid)
		{
			return new Response<ProblemDetails>(message: "Doğrulama hatası", success: false, ModelValidationProblem(modelState, "Formda gönderilen alanlar geçersiz veya eksik."));
		}

		if (await _unitOfWork.BibliographyReadRepository.AnyAsync(b => b.Url.Equals(data.Url)))
			return new Response<ProblemDetails>(message: "Aynı url değeri ile kaynak sistemde tanımlı.", success: false);

		await _unitOfWork.BibliographyWriteRepository.InsertAsync(new Domain.Entities.Bibliography()
		{
			UserId = _authUserInfoService.Id,
			Title = data.Title,
			Url = data.Url,
			CreatedDate = DateTime.Now,
			Status = data.Status
		});

		int result = await _unitOfWork.SaveAsync();

		if (result == 1)
		{
			return new Response<ProblemDetails>(message: "Kaynakça başarıyla eklendi.", success: true);
		}
		else
		{
			return new Response<ProblemDetails>(message: "Kaynakça ekleme sırasında bir hata oluştu. Daha sonra tekrar deneyiniz.", success: false);
		}
	}
	#endregion

	#region Read
	public async Task<PagingDataResponse<BibliographyListDto>> GetBibliographyListAsync(DataListRequest request)
	{
		var data = await _unitOfWork.BibliographyReadRepository.GetBibliographyListAsync(request);

		return data;
	}
	#endregion

	#region Update

	#endregion

	#region Delete

	#endregion
	#endregion
}
