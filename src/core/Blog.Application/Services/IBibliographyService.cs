using Blog.Application.Dto.BibliographyDto;
using Blog.Application.Request;
using Blog.Application.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blog.Application.Services;

public interface IBibliographyService
{
	#region Functions
	#region Create
	Task<Response<ProblemDetails>> InsertAsync(BibliographyInsertDto data, ModelStateDictionary modelState);
	#endregion

	#region Read
	Task<PagingDataResponse<BibliographyListDto>> GetBibliographyListAsync(DataListRequest request);
	#endregion

	#region Update

	#endregion

	#region Delete

	#endregion
	#endregion

}
