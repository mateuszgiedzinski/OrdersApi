using MagCoders.Orders.Shared.Abstractions;
using MagCoders.Orders.Shared.Infrastructure.Commands;
using MagCoders.Orders.Shared.Infrastructure.EventHandlers;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace MagCoders.Orders.Shared.Infrastructure;

/// <summary>
/// Shared module.
/// </summary>
public static class SharedModule
{
	/// <summary>
	/// Add module services.
	/// </summary>
	/// <param name="services">IServiceCollection.</param>
	/// <returns>Updated IServiceCollection.</returns>
	public static IServiceCollection AddSharedModule(this IServiceCollection services)
	{
		services.AddTransient(typeof(INotificationHandler<>), typeof(MediatrEventHandlerAdapter<>));
		services.AddTransient(typeof(IRequestHandler<,>), typeof(MediatRQueryHandlerAdapter<,>));
		services.AddTransient(typeof(IRequestHandler<>), typeof(MediatRCommandHandlerAdapter<>));
		services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

		return services;
	}
}