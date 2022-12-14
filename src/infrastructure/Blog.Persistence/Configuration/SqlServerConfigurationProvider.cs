using Microsoft.Extensions.Configuration;

namespace Blog.Persistence.Configuration;

public class SqlServerConfigurationProvider : ConfigurationProvider
{
	private readonly SqlServerConfigurationSource _configurationSource;

	public SqlServerConfigurationProvider(SqlServerConfigurationSource configurationSource)
	{
		_configurationSource = configurationSource;
	}

	public override void Load()
	{
		var settings = new Dictionary<string, string>();

		//TODO : veritabanından oku ve settings'i doldur.

		Data = settings;
	}
}
