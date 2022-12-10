using System.Linq.Expressions;

namespace Blog.Persistence.Specification
{
	public class AndSpecification<T> : Specification<T>
	{
		private readonly ISpecification<T> _left;
		private readonly ISpecification<T> _right;

		public AndSpecification(ISpecification<T> left, ISpecification<T> right)
		{
			_left = left;
			_right = right;
		}

		public override Expression<Func<T, bool>> ToExpression()
		{
			Expression<Func<T, bool>> leftExpression = _left.ToExpression();
			Expression<Func<T, bool>> rightExpression = _right.ToExpression();

			BinaryExpression andExpression = Expression.AndAlso(leftExpression.Body, rightExpression.Body);

			return Expression.Lambda<Func<T, bool>>(andExpression, leftExpression.Parameters.Single());
		}
	}
}
