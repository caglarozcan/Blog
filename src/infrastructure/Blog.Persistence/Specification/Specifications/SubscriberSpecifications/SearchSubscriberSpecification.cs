using Blog.Domain.Entities;
using System.Linq.Expressions;

namespace Blog.Persistence.Specification.Specifications.SubscriberSpecifications;

public class SearchSubscriberSpecification : Specification<Subscriber>
{
	private readonly string _searchValue;

	public SearchSubscriberSpecification(string searchValue)
	{
		_searchValue = searchValue;
	}

	public override Expression<Func<Subscriber, bool>> ToExpression()
	{
		DateTime searchDate;
		if (DateTime.TryParse(_searchValue, out searchDate))
		{
			return c => c.CreatedDate.Equals(searchDate) || c.UpdatedDate.Equals(searchDate);
		}

		return String.IsNullOrWhiteSpace(_searchValue) ?
			(c => true) :
			(c => c.FirsName.Contains(_searchValue) || c.LastName.Contains(_searchValue) || c.Email.Contains(_searchValue));
	}
}
