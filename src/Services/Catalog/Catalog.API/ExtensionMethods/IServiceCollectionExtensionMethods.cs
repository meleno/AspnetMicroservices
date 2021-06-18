using Catalog.API.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Catalog.API.ExtensionMethods
{
	public static class IServiceCollectionExtensionMethods
	{
		public static void AddMongoClient(this IServiceCollection services, IConfiguration config)
		{
			var configurationSection = config.GetSection(DatabaseOptions.SettingName);
			var dbOptions = configurationSection.Get<DatabaseOptions>();
			services.Configure<DatabaseOptions>(configurationSection);
			services.AddScoped<MongoClient>(x => new MongoClient(dbOptions.ConnectionString));
		}
	}
}
