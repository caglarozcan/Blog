using Blog.Application.Dto.UserDto;
using Blog.Application.Request;
using Blog.Application.Response;
using Blog.Application.Services;
using Blog.Application.UnitOfWork;

namespace Blog.Infrastructure.Services
{
	public class UserService : BaseService, IUserService
	{
		private readonly IUnitOfWork _unitOfWork;

		public UserService(IUnitOfWork unitOfWork)
		{
			this._unitOfWork = unitOfWork;
		}

		#region Read
		public async Task<PagingDataResponse<UserListDto>> GetUserListAsync(DataListRequest request)
		{
			var userList = await _unitOfWork.UserReadRepository.GetUserListAsync(request);

			return userList;
		}
		#endregion
	}
}
