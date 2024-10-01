/*using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MagCoders.Orders.Modules.Core.Infrastructure.Data;

/// <summary>
/// provides a new instance of a DbContext for use in design-time scenarios, such as running migrations.
/// </summary>
public class CoreDbContextFactory : IDesignTimeDbContextFactory<CoreDbContext>
{
	/// <inheritdoc/>
	public CoreDbContext CreateDbContext(string[] args)
	{
		IConfigurationRoot configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
										.AddJsonFile("appsettings.json")
										.AddJsonFile("appsettings.Development.json")
										.Build();

		var optionsBuilder = new DbContextOptionsBuilder<CoreDbContext>();
		optionsBuilder.UseSqlServer(cfg => cfg.configuration.GetConnectionString("appDb"));


		return new CoreDbContext(optionsBuilder.Options);
	}
}*/