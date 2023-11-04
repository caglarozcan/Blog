using Blog.Application.Dto.SettingDto;
using Blog.Application.Response;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blog.Application.Services;

public interface ISettingService
{
	#region Create

	#endregion

	#region Read
	ValueTask<List<SettingGroupListDto>> GetSettingsAsync();
	#endregion

	#region Update
	ValueTask<Response<Microsoft.AspNetCore.Mvc.ProblemDetails>> SaveGeneralSettingsAsync(GeneralSettingUpdateDto data, ModelStateDictionary modelState);

	ValueTask<Response<Microsoft.AspNetCore.Mvc.ProblemDetails>> SaveArticleSettingsAsync(ArticleSettingUpdateDto data, ModelStateDictionary modelState);

	ValueTask<Response<Microsoft.AspNetCore.Mvc.ProblemDetails>> SaveFileUploadSettingsAsync(FileUploadSettingUpdateDto data, ModelStateDictionary modelState);

	ValueTask<Response<Microsoft.AspNetCore.Mvc.ProblemDetails>> SaveMailSettingsAsync(EmailSettingUpdateDto data, ModelStateDictionary modelState);

	ValueTask<Response<Microsoft.AspNetCore.Mvc.ProblemDetails>> SaveCommentSettingsAsync(CommentSettingUpdateDto data, ModelStateDictionary modelState);

	ValueTask<Response<Microsoft.AspNetCore.Mvc.ProblemDetails>> SavePagingSettingsAsync(PagingSettingUpdateDto data, ModelStateDictionary modelState);
	#endregion

	#region Delete

	#endregion
}
