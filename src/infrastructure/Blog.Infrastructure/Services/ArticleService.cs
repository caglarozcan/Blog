using Blog.Application.Dto.ArticleDto;
using Blog.Application.Response;
using Blog.Application.Services;
using Blog.Application.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blog.Infrastructure.Services;

public class ArticleService : BaseService, IArticleService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly ITextService _textService;

	public ArticleService(IUnitOfWork unitOfWork,
		ITextService textService)
	{
		this._unitOfWork = unitOfWork;
		_textService = textService;
	}

	public async ValueTask<Response<ProblemDetails>> InsertAsync(ArticleInsertDto data, ModelStateDictionary modelState)
	{
		if (!modelState.IsValid)
			return new Response<ProblemDetails>(message: "Doğrulama hatası", success: false, ModelValidationProblem(modelState, "Formda gönderilen alanlar geçersiz veya eksik."));

		if (String.IsNullOrWhiteSpace(data.Slug)) data.Slug = _textService.Slug(data.Title);

		return new Response<ProblemDetails>(message: "Makale başarıyla eklendi.", success: true);
	}
}
