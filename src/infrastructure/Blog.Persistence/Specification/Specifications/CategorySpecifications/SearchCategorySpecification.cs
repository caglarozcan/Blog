using Blog.Domain.Entities;
using System.Linq.Expressions;

namespace Blog.Persistence.Specification.Specifications.CategorySpecifications
{
	public class SearchCategorySpecification : Specification<Category>
	{
		private readonly string _searchValue;

		public SearchCategorySpecification(string searchValue)
		{
			_searchValue = searchValue;
		}

		public override Expression<Func<Category, bool>> ToExpression()
		{
			DateTime searchDate;
			if(DateTime.TryParse(_searchValue, out searchDate))
			{
				return c => c.CreatedDate.Equals(searchDate);
			}

			return String.IsNullOrEmpty(_searchValue) ? c => 1 == 1 : c => c.Title.Contains(_searchValue) || c.Slug.Contains(_searchValue);
		}
	}
}
