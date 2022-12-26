using Blog.Application.Services;
using Blog.Application.UnitOfWork;

namespace Blog.Infrastructure.Services;

public class BibliographyService : IBibliographyService
{
	private IUnitOfWork _unitOfWork;

	public BibliographyService(IUnitOfWork unitOfWork)
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
