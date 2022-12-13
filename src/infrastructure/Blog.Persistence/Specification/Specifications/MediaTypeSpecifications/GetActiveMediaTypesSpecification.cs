using Blog.Domain.Entities;
using System.Linq.Expressions;

namespace Blog.Persistence.Specification.Specifications.MediaTypeSpecifications
{
	public class GetActiveMediaTypesSpecification : Specification<MediaType>
	{
		public override Expression<Func<MediaType, bool>> ToExpression()
		{
			return m => m.Status == 1;
		}
	}
}
