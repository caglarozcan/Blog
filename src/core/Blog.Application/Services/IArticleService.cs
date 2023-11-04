using Blog.Application.Dto.ArticleDto;
using Blog.Application.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blog.Application.Services;

public interface IArticleService
{
	ValueTask<Response<ProblemDetails>> InsertAsync(ArticleInsertDto data, ModelStateDictionary modelState);
}
