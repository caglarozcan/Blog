using Blog.Application.Enums;
using System.Linq.Expressions;
using System.Reflection;

namespace Blog.Application.Extension.PredicateBuilder
{
	public static class PredicateBuilder
	{
		public static IQueryable<T> WherePredicate<T>(this IQueryable<T> source, string filterText)
		{
			Expression<Func<T, bool>> where = p => 1 != 1;

			int intPredicate = 0;
			bool isIntPredicate = int.TryParse(filterText, out intPredicate);

			DateTime datePredicate;
			bool isDatePredicate = DateTime.TryParse(filterText, out datePredicate);

			PropertyInfo[] props = typeof(T).GetProperties();

			foreach (var item in props)
			{
				if (isDatePredicate)
				{
					if (item.PropertyType.Name == typeof(DateTime).Name)
					{
						//DateTime alana göre arama yap
						ParameterExpression pe = Expression.Parameter(typeof(T), typeof(T).FullName);
						MemberExpression me = Expression.Property(pe, item.Name);
						ConstantExpression ce = Expression.Constant(datePredicate, typeof(DateTime));
						BinaryExpression body = Expression.Equal(me, ce);
						var exp = Expression.Lambda<Func<T, bool>>(body, new[] { pe });
						where = where.Or<T>(exp);
					}
				}
				else
				{
					//integer alana göre arama yap.
					if (isIntPredicate && (item.PropertyType.Name == typeof(int).Name || item.PropertyType.Name == typeof(byte).Name))
					{
						ParameterExpression pe = Expression.Parameter(typeof(T), typeof(T).FullName);
						MemberExpression me = Expression.Property(pe, item.Name);
						ConstantExpression ce = Expression.Constant(intPredicate, item.PropertyType);
						BinaryExpression body = Expression.Equal(me, ce);
						var exp = Expression.Lambda<Func<T, bool>>(body, new[] { pe });
						where = where.Or<T>(exp);
					}

					//Buarada aynı zamanda string alana göre de arama yapılabilir. Çünkü string ifade içerisinde bir sayı geçiyor olabilir.
					if (item.PropertyType.Name == typeof(string).Name)
					{
						var parameter = Expression.Parameter(typeof(T), typeof(T).FullName);
						var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
						var paramValue = Expression.Constant(filterText, typeof(string));
						var containsCall = Expression.Call(Expression.Property(parameter, item.Name), containsMethod, new Expression[1] { paramValue });
						var isRight = Expression.Constant(true, typeof(bool));
						BinaryExpression body = Expression.Equal(containsCall, isRight);
						var exp = Expression.Lambda<Func<T, bool>>(body, new[] { parameter });
						where = where.Or<T>(exp);
					}
				}
			}

			return source.Where(where);
		}

		public static IQueryable<T> OrderByPredicate<T>(this IQueryable<T> source, int sortColumnIndex, Sorting sortType)
		{
			PropertyInfo[] props = typeof(T).GetProperties();

			ParameterExpression parameter = Expression.Parameter(source.ElementType, "");
			MemberExpression property = Expression.Property(parameter, props[sortColumnIndex].Name);
			LambdaExpression lambda = Expression.Lambda(property, parameter);

			string methodName = sortType == Sorting.Ascending ? "OrderBy" : "OrderByDescending";

			Expression methodCallExpression = Expression.Call(typeof(Queryable), methodName,
								  new Type[] { source.ElementType, property.Type },
								  source.Expression, Expression.Quote(lambda));

			return source.Provider.CreateQuery<T>(methodCallExpression);
		}
	}
}
