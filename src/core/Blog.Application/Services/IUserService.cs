using Blog.Application.Dto.UserDto;
using Blog.Application.Request;
using Blog.Application.Response;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Application.Services;

public interface IUserService
{
	#region Create
	Task<Response<ProblemDetails>> InsertAsync(UserInsertDto data, ModelStateDictionary modelState);
	#endregion

	#region Read
	Task<PagingDataResponse<UserListDto>> GetUserListAsync(DataListRequest request);

	Task<UserUpdateDto> GetUpdatedUserAsync(Guid id);
	#endregion

	#region Update
	Task<Response<ProblemDetails>> UpdateAsync(UserUpdateDto data, ModelStateDictionary modelState);

	Task<Response.Response> StatusChangeAsync(Guid id);
	#endregion

	#region Delete
	Task<Response.Response> DeleteAsync(Guid id);
	#endregion


}
