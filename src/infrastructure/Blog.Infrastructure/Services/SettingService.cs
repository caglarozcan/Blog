using Blog.Application.Services;
using Blog.Application.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Services
{
	public class SettingService : ISettingService
	{
		private readonly IUnitOfWork _unitOfWork;

		public SettingService(IUnitOfWork unitOfWork)
		{
			this._unitOfWork = unitOfWork;
		}
	}
}
