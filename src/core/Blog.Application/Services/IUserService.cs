using Blog.Application.Dto.UserDto;
using Blog.Application.Request;
using Blog.Application.Response;

namespace Blog.Application.Services
{
	public interface IUserService
	{
		Task<PagingDataResponse<UserListDto>> GetUserListAsync(DataListRequest request);
	}
}
