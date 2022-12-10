using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Persistence.Specification
{
	public class NotSpecification<T> : Specification<T>
	{
		private readonly ISpecification<T> _left;
		private readonly ISpecification<T> _right;

		public NotSpecification(ISpecification<T> left, ISpecification<T> right)
		{
			_left = left;
			_right = right;
		}

		public override Expression<Func<T, bool>> ToExpression()
		{
			Expression<Func<T, bool>> leftExpression = _left.ToExpression();
			Expression<Func<T, bool>> rightExpression = _right.ToExpression();

			BinaryExpression notExpression = Expression.NotEqual(leftExpression.Body, rightExpression.Body);

			return Expression.Lambda<Func<T, bool>>(notExpression, leftExpression.Parameters.Single());
		}
	}
}
