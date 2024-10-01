using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MagCoders.Orders.Modules.Stock.Infrastructure.Data;

/// <summary>
/// provides a new instance of a DbContext for use in design-time scenarios, such as running migrations.
/// </summary>
public class StockDbContextFactory : IDesignTimeDbContextFactory<StockDbContext>
{
	/// <inheritdoc/>
	public StockDbContext CreateDbContext(string[] args)
	{
		IConfigurationRoot configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
										.AddJsonFile("appsettings.json")
										.AddJsonFile("appsettings.Development.json")
										.Build();

		var optionsBuilder = new DbContextOptionsBuilder<StockDbContext>();
		optionsBuilder.UseSqlServer(configuration.GetConnectionString("DockerDb"));

		return new StockDbContext(optionsBuilder.Options);
	}
}