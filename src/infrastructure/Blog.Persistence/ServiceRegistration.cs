using Blog.Application.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Persistence;

public static class ServiceRegistration
{
	public static void AddPersistenceServices(this IServiceCollection collection)
	{
		collection.AddTransient<IUnitOfWork, UnitOfWork>();
	}
}
