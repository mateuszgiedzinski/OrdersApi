using MagCoders.Orders.Modules.Core.Contracts.Events.Orders;
using MagCoders.Orders.Shared.Abstractions.Attributes;
using MagCoders.Orders.Shared.Infrastructure.EventHandlers;

using Microsoft.Extensions.DependencyInjection;

namespace MagCoders.Orders.Modules.Core.Application.Order.EventHandlers;

/// <summary>
/// Order created domain event handler.
/// </summary>
[Lifetime(Lifetime = ServiceLifetime.Singleton)]
public class OrderCreatedDomainEventHandler : IDomainEventHandler<OrderCreatedDomainEvent>
{
	/// <summary>
	/// Handle the notification.
	/// </summary>
	/// <param name="notification">Notification.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>Task.</returns>
	public Task Handle(OrderCreatedDomainEvent notification, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();

		return Task.CompletedTask;
	}
}