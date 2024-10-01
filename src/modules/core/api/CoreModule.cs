using FluentValidation;
using MagCoders.Orders.Modules.Core.Application.Customer.CreatingCustomer.CreatingCustomer;
using MagCoders.Orders.Modules.Core.Application.Order.CreatingOrder;
using MagCoders.Orders.Modules.Core.Application.Order.GettingOrders;
using MagCoders.Orders.Modules.Core.Infrastructure.Data;
using MagCoders.Orders.Shared.Abstractions.Extensions;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MagCoders.Orders.Modules.Core.Api;

/// <summary>
/// Core order module.
/// </summary>
public static class CoreModule
{
	/// <summary>
	/// Add module services.
	/// </summary>
	/// <param name="services">IServiceCollection.</param>
	/// <param name="configurationManager">ConfigurationManager.</param>
	/// <returns>Updated IServiceCollection.</returns>
	public static IServiceCollection AddCoreModule(
		this IServiceCollection services,
		ConfigurationManager configurationManager)
	{
		services.AddDbContext<CoreDbContext>(
			options => options.UseSqlServer(
				configurationManager.GetConnectionString("appDb"),
				cfg =>
				{
					cfg.EnableRetryOnFailure(10);
					cfg.MigrationsHistoryTable("__EFMigrationsHistory", "core");
				}));
		services.AddValidatorsFromAssembly(typeof(CreateOrderValidator).Assembly, ServiceLifetime.Singleton);
		services.AddSingleton<IValidator<CreateCustomer>, CreateOrderValidator>();
		services.AddSingleton<IValidator<GetOrders>, GetOrdersValidator>();
		return services;
	}

	/// <summary>
	/// Customizes app building process.
	/// </summary>
	/// <param name="app">IApplicationBuilder.</param>
	/// <returns>Updated IApplicationBuilder.</returns>
	public static IApplicationBuilder UseCoreModule(this IApplicationBuilder app)
	{
		app.InitDatabase<CoreDbContext>().GetAwaiter().GetResult();
		return app;
	}
}