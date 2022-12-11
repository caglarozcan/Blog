using System.Linq.Expressions;

namespace Blog.Persistence.Specification
{
	public abstract class Specification<T> : ISpecification<T>
	{
		public bool IsSatisfiedBy(T entity)
		{
			return ToExpression().Compile()(entity);
		}

		public abstract Expression<Func<T, bool>> ToExpression();

		public ISpecification<T> And(ISpecification<T> other)
		{
			return new AndSpecification<T>(this, other);
		}

		public ISpecification<T> Or(ISpecification<T> other)
		{
			return new OrSpecification<T>(this, other);
		}
	}
}
