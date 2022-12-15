using Microsoft.Extensions.Configuration;

namespace Blog.Persistence.Configuration;

public class SqlServerConfigurationSource : IConfigurationSource
{
	public string ConnectionString { get; set; }

	public IConfigurationProvider Build(IConfigurationBuilder builder)
	{
		return new SqlServerConfigurationProvider(this);
	}
}
