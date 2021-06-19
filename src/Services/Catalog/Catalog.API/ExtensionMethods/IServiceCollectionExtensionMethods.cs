using Catalog.API.Data;
using Catalog.API.Options;
using Catalog.API.Repositories;
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
			services.AddScoped(x => new MongoClient(dbOptions.ConnectionString));
		}

		public static void AddServices(this IServiceCollection services)
		{
			services.AddScoped<ICatalogContext, CatalogContext>();
			services.AddScoped<IProductRepository, ProductRepository>();
		}
	}
}
