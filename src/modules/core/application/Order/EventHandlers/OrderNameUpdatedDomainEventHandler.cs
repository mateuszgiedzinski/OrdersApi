using MagCoders.Orders.Modules.Core.Contracts.Events.Orders;
using MagCoders.Orders.Shared.Abstractions.Attributes;
using MagCoders.Orders.Shared.Infrastructure.EventHandlers;

using Microsoft.Extensions.DependencyInjection;

namespace MagCoders.Orders.Modules.Core.Application.Order.EventHandlers;

/// <summary>
/// Order name updated domain event handler.
/// </summary>
[Lifetime(Lifetime = ServiceLifetime.Singleton)]
public class OrderNameUpdatedDomainEventHandler : IDomainEventHandler<OrderUpdatedDomainEvent>
{
	/// <summary>
	/// Handle the notification.
	/// </summary>
	/// <param name="notification">Notification.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>Task.</returns>
	public Task Handle(OrderUpdatedDomainEvent notification, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();

		// TODO: Add logging using ILogger
		return Task.CompletedTask;
	}
}