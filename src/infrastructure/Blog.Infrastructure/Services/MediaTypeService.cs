using Blog.Application.Services;
using Blog.Application.UnitOfWork;

namespace Blog.Infrastructure.Services
{
	public class MediaTypeService : BaseService, IMediaTypeService
	{
		private readonly IUnitOfWork _unitOfWork;

		public MediaTypeService(IUnitOfWork unitOfWork)
		{
			this._unitOfWork = unitOfWork;
		}
	}
}
