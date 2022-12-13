using Blog.Domain.Entities;
using System.Linq.Expressions;

namespace Blog.Persistence.Specification.Specifications.UserSpecifications
{
	public class SearchUserSpecification : Specification<User>
	{
		private readonly string _searchValue;

		public SearchUserSpecification(string searchValue)
		{
			_searchValue = searchValue;
		}

		public override Expression<Func<User, bool>> ToExpression()
		{
			DateTime searchDate;
			if (DateTime.TryParse(_searchValue, out searchDate))
			{
				return c => c.CreatedDate.Date.Equals(searchDate);
			}

			return String.IsNullOrWhiteSpace(_searchValue) ? c => true : c => 
				c.Name.Contains(_searchValue) || 
				c.LastName.Contains(_searchValue) ||
				c.Email.Contains(_searchValue) ||
				c.NickName.Contains(_searchValue);
		}
	}
}
