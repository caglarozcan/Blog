using Blog.Application.Dto.UserDto;
using Blog.Application.Request;
using Blog.Application.Response;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Application.Services;

public interface IUserService
{
	#region Create
	ValueTask<Response<ProblemDetails>> InsertAsync(UserInsertDto data, ModelStateDictionary modelState);
	#endregion

	#region Read
	ValueTask<PagingDataResponse<UserListDto>> GetUserListAsync(DataListRequest request);

	ValueTask<UserUpdateDto> GetUpdatedUserAsync(Guid id);
	#endregion

	#region Update
	ValueTask<Response<ProblemDetails>> UpdateAsync(UserUpdateDto data, ModelStateDictionary modelState);

	ValueTask<Response.Response> StatusChangeAsync(Guid id);
	#endregion

	#region Delete
	ValueTask<Response.Response> DeleteAsync(Guid id);
	#endregion
}
