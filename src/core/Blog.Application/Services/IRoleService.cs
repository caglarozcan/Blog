using Blog.Application.Dto.RoleDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services
{
    public interface IRoleService
    {
		#region Read
		Task<List<RoleSelectDto>> GetSelectRolesAsync();
		#endregion
	}
}
