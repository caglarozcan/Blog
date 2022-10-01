using Blog.Application.Dto.RoleDto;
using Blog.Application.Services;
using Blog.Application.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Services
{
    public class RoleService : BaseService, IRoleService
    {
		private readonly IUnitOfWork _unitOfWork;

		public RoleService(IUnitOfWork unitOfWork)
		{
			this._unitOfWork = unitOfWork;
		}

		#region Read
		public async Task<RoleSelectDto> GetSelectRolesAsync(Guid? id)
        {
			return await _unitOfWork.RoleReadRepository.GetSelectRolesAsync(id);
		}
		#endregion
	}
}
