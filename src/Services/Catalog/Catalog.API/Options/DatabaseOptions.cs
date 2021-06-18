namespace Catalog.API.Options
{
	public class DatabaseOptions
	{
		public const string SettingName = "DatabaseSettings";

		public string ConnectionString { get; set; }

		public string DatabaseName { get; set; }

		public string CollectionName { get; set; }
	}
}
