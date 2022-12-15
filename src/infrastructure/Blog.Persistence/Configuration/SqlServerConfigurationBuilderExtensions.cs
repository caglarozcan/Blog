using Microsoft.Extensions.Configuration;

namespace Blog.Persistence.Configuration;

public static class SqlServerConfigurationBuilderExtensions
{
	public static IConfigurationBuilder AddSqlServer(this IConfigurationBuilder builder, string connectionString)
	{
		return builder.Add(new SqlServerConfigurationSource { ConnectionString = connectionString});
	}
}
