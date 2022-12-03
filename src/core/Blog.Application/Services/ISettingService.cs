using Blog.Application.Dto.SettingDto;
using Blog.Application.Response;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blog.Application.Services
{
	public interface ISettingService
	{
		#region Create

		#endregion

		#region Read
		Task<List<SettingGroupListDto>> GetSettingsAsync();
		#endregion

		#region Update
		Task<Response<Microsoft.AspNetCore.Mvc.ProblemDetails>> SaveGeneralSettingsAsync(GeneralSettingUpdateDto data, ModelStateDictionary modelState);

		Task<Response<Microsoft.AspNetCore.Mvc.ProblemDetails>> SaveArticleSettingsAsync(ArticleSettingUpdateDto data, ModelStateDictionary modelState);

		Task<Response<Microsoft.AspNetCore.Mvc.ProblemDetails>> SaveFileUploadSettingsAsync(FileUploadSettingUpdateDto data, ModelStateDictionary modelState);

		Task<Response<Microsoft.AspNetCore.Mvc.ProblemDetails>> SaveMailSettingsAsync(EmailSettingUpdateDto data, ModelStateDictionary modelState);

		Task<Response<Microsoft.AspNetCore.Mvc.ProblemDetails>> SaveCommentSettingsAsync(CommentSettingUpdateDto data, ModelStateDictionary modelState);

		Task<Response<Microsoft.AspNetCore.Mvc.ProblemDetails>> SavePagingSettingsAsync(PagingSettingUpdateDto data, ModelStateDictionary modelState);
		#endregion

		#region Delete

		#endregion
	}
}
