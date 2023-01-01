using Blog.Domain.Entities;
using System.Linq.Expressions;

namespace Blog.Persistence.Specification.Specifications.BibliographySpecifications;

public class SearchBibliographySpecification : Specification<Bibliography>
{
	private readonly string _searchValue;

	public SearchBibliographySpecification(string searchValue)
	{
		_searchValue = searchValue;
	}

	public override Expression<Func<Bibliography, bool>> ToExpression()
	{
		DateTime searchDate;
		if (DateTime.TryParse(_searchValue, out searchDate))
			return c => c.CreatedDate.Date.Equals(searchDate);

		return String.IsNullOrWhiteSpace(_searchValue) ? c => true : c => c.Title.Contains(_searchValue) || c.Url.Contains(_searchValue);
	}
}
