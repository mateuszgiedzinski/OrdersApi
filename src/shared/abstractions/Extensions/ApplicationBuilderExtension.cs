using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;

namespace MagCoders.Orders.Shared.Abstractions.Extensions;

/// <summary>
/// Class contains methods that extend ApplicationBuilder.
/// </summary>
public static class ApplicationBuilderExtension
{
	/// <summary>
	/// Enables migrations on startup for provided context class.
	/// </summary>
	/// <typeparam name="T">DbContext class to make migrations for.</typeparam>
	/// <param name="app">IApplicationBuilder.</param>
	/// <param name="attempt">Attempt number.</param>
	/// <returns>Updated IApplicationBuilder.</returns>
	public static async Task<IApplicationBuilder> InitDatabase<T>(this IApplicationBuilder app, int attempt = 0)
		where T : DbContext
	{
		try
		{
			if (!EF.IsDesignTime)
			{
				using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope();
				var dbContext = scope.ServiceProvider
					.GetRequiredService<T>();
				bool dbReady = false;
				bool hasPendingMigrations = false;
				while (!dbReady)
				{
					var pendingMigrations = dbContext.Database.GetPendingMigrations();
					var appliedMigrations = dbContext.Database.GetAppliedMigrations();
					if (appliedMigrations.Any() || (pendingMigrations.Count() == 0 && appliedMigrations.Count() == 0))
					{
						dbReady = true;
						hasPendingMigrations = pendingMigrations.Any();
					}
					else
					{
						await Task.Delay(3000);
					}
				}

				if (hasPendingMigrations)
				{
					dbContext.Database.Migrate();
				}
			}
		}
		catch (Exception)
		{
			if (attempt > 5)
			{
				throw;
			}

			await InitDatabase<T>(app, attempt + 1);
		}

		return app;
	}
}