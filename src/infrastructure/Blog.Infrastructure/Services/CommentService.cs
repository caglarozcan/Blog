using Blog.Application.Services;
using Blog.Application.UnitOfWork;

namespace Blog.Infrastructure.Services;

public class CommentService : ICommentService
{
	private readonly IUnitOfWork _unitOfWork;

	public CommentService(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	#region Functions
	#region Create

	#endregion

	#region Read

	#endregion

	#region Update

	#endregion

	#region Delete

	#endregion
	#endregion
}
