using System.Linq.Expressions;

namespace Blog.Application.Extension.PredicateBuilder
{
	public static class PredicateBuilderExtension
	{
		public static Expression<Func<T, bool>> True<T>()
		{
			return input => true;
		}

		public static Expression<Func<T, bool>> False<T>()
		{
			return input => false;
		}

		public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expression, Expression<Func<T, bool>> predicate)
		{
			InvocationExpression invocation = Expression.Invoke(predicate, expression.Parameters.Cast<Expression>());
			return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expression.Body, invocation), expression.Parameters);
		}

		public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expression, Expression<Func<T, bool>> predicate)
		{
			InvocationExpression invocation = Expression.Invoke(predicate, expression.Parameters.Cast<Expression>());
			return Expression.Lambda<Func<T, bool>>(Expression.OrElse(expression.Body, invocation), expression.Parameters);
		}
	}
}
