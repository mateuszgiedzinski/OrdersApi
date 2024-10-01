using FluentValidation;
using MagCoders.Orders.Modules.Stock.Application.Product.CreatingProduct;
using MagCoders.Orders.Modules.Stock.Application.Product.GettingProducts;
using MagCoders.Orders.Modules.Stock.Infrastructure.Data;

using MagCoders.Orders.Shared.Abstractions.Extensions;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MagCoders.Orders.Modules.Stock.Api;

/// <summary>
/// Core order module.
/// </summary>
public static class StockModule
{
	/// <summary>
	/// Add module services.
	/// </summary>
	/// <param name="services">IServiceCollection.</param>
	/// <param name="configurationManager">ConfigurationManager.</param>
	/// <returns>Updated IServiceCollection.</returns>
	public static IServiceCollection AddStockModule(
		this IServiceCollection services,
		ConfigurationManager configurationManager)
	{
		services.AddDbContext<StockDbContext>(
			options => options.UseSqlServer(
				configurationManager.GetConnectionString("appDb"),
				cfg =>
				{
					cfg.EnableRetryOnFailure(10);
					cfg.MigrationsHistoryTable("__EFMigrationsHistory", "stock");
				}));
		services.AddSingleton<IValidator<CreateProduct>, CreateProductValidator>();
		services.AddSingleton<IValidator<GetProducts>, GetProductsValidator>();
		return services;
	}

	/// <summary>
	/// Customizes app building process.
	/// </summary>
	/// <param name="app">IApplicationBuilder.</param>
	/// <returns>Updated IApplicationBuilder.</returns>
	public static IApplicationBuilder UseStockModule(this IApplicationBuilder app)
	{
		app.InitDatabase<StockDbContext>().GetAwaiter().GetResult();
		return app;
	}
}