using Blog.Application.Services;
using Blog.Application.UnitOfWork;

namespace Blog.Infrastructure.Services
{
	public class MediaService : BaseService, IMediaService
	{
		private readonly IUnitOfWork _unitOfWork;
		private IFileIOService _fileIOService;

		public MediaService(IUnitOfWork unitOfWork, IFileIOService fileIOService)
		{
			this._unitOfWork = unitOfWork;
			this._fileIOService = fileIOService;
		}
	}
}
