using MagCoders.Orders.Modules.Stock.Contracts.Events;
using MagCoders.Orders.Shared.Abstractions.Attributes;
using MagCoders.Orders.Shared.Infrastructure.EventHandlers;

using Microsoft.Extensions.DependencyInjection;

namespace MagCoders.Orders.Modules.Stock.Application.Product.EventHandlers;

/// <summary>
/// Product created domain event handler.
/// </summary>
[Lifetime(Lifetime = ServiceLifetime.Singleton)]
public class ProductCreatedDomainEventHandler : IDomainEventHandler<ProductCreatedDomainEvent>
{
	/// <summary>
	/// Handle the notification.
	/// </summary>
	/// <param name="notification">Notification.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>Task.</returns>
	public Task Handle(ProductCreatedDomainEvent notification, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();

		return Task.CompletedTask;
	}
}