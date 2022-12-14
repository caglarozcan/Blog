using Blog.Application.Dto.RoleDto;
using Blog.Application.Dto.UserDto;
using Blog.Application.Extension.Pagination;
using Blog.Application.Extension.PredicateBuilder;
using Blog.Application.Repository;
using Blog.Application.Request;
using Blog.Application.Response;
using Blog.Domain.Entities;
using Blog.Persistence.Specification.Specifications.UserSpecifications;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repository
{
	public class UserReadRepository : ReadRepository<User>, IUserReadRepository
	{
		private DbSet<UserRoles> _userRoleTable { get; }

		public UserReadRepository(DbContext dbContext) 
			: base(dbContext)
		{
			this._userRoleTable = dbContext.Set<UserRoles>();
		}

		public async Task<UserRoleDto> GetAuthenticatedUserRolesAsync(Guid userId)
		{
			var role = await _userRoleTable.AsNoTracking().Where(r => r.UserId == userId).Include(i => i.Role).FirstOrDefaultAsync();

			return new UserRoleDto()
			{
				Id = role.RoleId,
				Name = role.Role.Name
			};
		}

		public async Task<PagingDataResponse<UserListDto>> GetUserListAsync(DataListRequest request)
		{
			SearchUserSpecification spec = new(request.SearchValue);

			var query = Table.AsNoTracking().Include(i => i.Roles).Where(spec.ToExpression()).Select(s => new UserListDto()
			{
				Id = s.Id,
				Name = s.Name,
				LastName = s.LastName,
				Email = s.Email,
				NickName = s.NickName,
				CreatedDate = s.CreatedDate,
				LastLogin = s.LastLogin,
				RoleName = s.Roles.First().Role.Name,
				Status = s.Status
			});

			if (request.SortType.HasValue)
			{
				query = query.OrderByPredicate(request.SortIndex.Value, request.SortType.Value);
			}

			return await query.ToPagingData(request.PerData, request.Page);
		}
	}
}
