using System.Linq.Expressions;

namespace Blog.Application.Extension.PredicateBuilder
{
	public static class PredicateBuilderExtension
	{
		public static Expression<Func<T, bool>> True<T>()
		{
			return (Expression<Func<T, bool>>)(input => true);
		}

		public static Expression<Func<T, bool>> False<T>()
		{
			return (Expression<Func<T, bool>>)(input => false);
		}

		public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expression, Expression<Func<T, bool>> predicate)
		{
			InvocationExpression invocation = Expression.Invoke((Expression)predicate, expression.Parameters.Cast<Expression>());
			return Expression.Lambda<Func<T, bool>>((Expression)Expression.AndAlso(expression.Body, (Expression)invocation), (IEnumerable<ParameterExpression>)expression.Parameters);
		}

		public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expression, Expression<Func<T, bool>> predicate)
		{
			InvocationExpression invocation = Expression.Invoke((Expression)predicate, expression.Parameters.Cast<Expression>());
			return Expression.Lambda<Func<T, bool>>((Expression)Expression.OrElse(expression.Body, (Expression)invocation), (IEnumerable<ParameterExpression>)expression.Parameters);
		}
	}
}
