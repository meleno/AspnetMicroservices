using Catalog.API.Entities;
using Catalog.API.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

namespace Catalog.API.Data
{
	public class CatalogContext : ICatalogContext
	{
		private readonly DatabaseOptions _dbConfig;
		private readonly MongoClient _dbClient;
		private IMongoCollection<Product> _products;

		public CatalogContext(IOptions<DatabaseOptions> dbConfig, MongoClient dbClient)
		{
			_dbConfig = dbConfig.Value ?? throw new ArgumentNullException(nameof(dbConfig));
			_dbClient = dbClient ?? throw new ArgumentNullException(nameof(dbClient));
		}

		public IMongoCollection<Product> Products
		{
			get
			{
				GetProducts();
				return _products;
			}
		}

		private void GetProducts()
		{
			if (_products == null)
			{
				var database = _dbClient.GetDatabase(_dbConfig.DatabaseName);
				_products = database.GetCollection<Product>(_dbConfig.CollectionName);
				CatalogContextSeed.SeedData(_products);
			}
		}
	}
}
