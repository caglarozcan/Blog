using Microsoft.Data.SqlClient;
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

		using (var connection = new SqlConnection(_configurationSource.ConnectionString))
		{
			var query = new SqlCommand(@"SELECT 
											CONCAT(SG.SettingKey, ':', S.SettingKey) AS SettingKey,
											S.Value
										FROM dbo.SettingGroup AS SG (NOLOCK)
											INNER JOIN dbo.Settings AS S (NOLOCK)
												ON S.SettingGroupId = SG.Id
										ORDER BY
											SG.Id", connection);

			query.Connection.Open();

			using (var reader = query.ExecuteReader())
			{
				while (reader.Read())
				{
					settings.Add(reader[0].ToString(), reader[1].ToString());
				}
			}
		}

		Data = settings;
	}
}
