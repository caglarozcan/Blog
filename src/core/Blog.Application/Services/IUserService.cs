using Blog.Application.Dto.UserDto;
using Blog.Application.Request;
using Blog.Application.Response;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Application.Services
{
	public interface IUserService
	{
		#region Create
		Task<Response<ProblemDetails>> InsertAsync(UserInsertDto data, ModelStateDictionary modelState);
		#endregion

		#region Read
		Task<PagingDataResponse<UserListDto>> GetUserListAsync(DataListRequest request);
		#endregion

		#region Update

		#endregion

		#region Delete

		#endregion


	}
}
