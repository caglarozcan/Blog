using Blog.Domain.Entities;
using System.Linq.Expressions;

namespace Blog.Persistence.Specification.Specifications.MediaTypeSpecifications
{
	public class SearchMediaTypeSpecification : Specification<MediaType>
	{
		private readonly string _searchValue;

		public SearchMediaTypeSpecification(string searchValue)
		{
			_searchValue = searchValue;
		}

		public override Expression<Func<MediaType, bool>> ToExpression()
		{
			DateTime searchDate;
			if (DateTime.TryParse(_searchValue, out searchDate))
			{
				return c => c.CreatedDate.Equals(searchDate);
			}

			return String.IsNullOrEmpty(_searchValue) ? 
				(c => true) : 
				(c => c.Title.Contains(_searchValue) || c.FileExtension.Contains(_searchValue) || c.MimeType.Contains(_searchValue));
		}
	}
}
