using MagCoders.Orders.Modules.Stock.Contracts.Events;
using MagCoders.Orders.Shared.Abstractions.Attributes;
using MagCoders.Orders.Shared.Infrastructure.EventHandlers;

using Microsoft.Extensions.DependencyInjection;

namespace MagCoders.Orders.Modules.Stock.Application.Product.EventHandlers;

/// <summary>
/// Product name updated domain event handler.
/// </summary>
[Lifetime(Lifetime = ServiceLifetime.Singleton)]
public class ProductNameUpdatedDomainEventHandler : IDomainEventHandler<ProductUpdatedDomainEvent>
{
	/// <summary>
	/// Handle the notification.
	/// </summary>
	/// <param name="notification">Notification.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>Task.</returns>
	public Task Handle(ProductUpdatedDomainEvent notification, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();

		// TODO: Add logging using ILogger
		return Task.CompletedTask;
	}
}