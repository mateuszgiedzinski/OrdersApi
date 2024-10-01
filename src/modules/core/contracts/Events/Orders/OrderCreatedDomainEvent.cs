using MagCoders.Orders.Modules.Core.Contracts.ValueObjects;
using MagCoders.Orders.Shared.Infrastructure.Events;

namespace MagCoders.Orders.Modules.Core.Contracts.Events.Orders;

/// <summary>
/// Order created domain event.
/// </summary>
public class OrderCreatedDomainEvent : DomainEvent
{
	/// <summary>
	/// Initializes a new instance of the <see cref="OrderCreatedDomainEvent"/> class.
	/// </summary>
	/// <param name="id">Order identifier.</param>
	/// <param name="customerId">Customer identifier which creates the order.</param>
	public OrderCreatedDomainEvent(OrderId id, CustomerId customerId)
	{
		this.Id = id;
		this.CustomerId = customerId;
	}

	/// <summary>
	/// Customer identifier which creates the order.
	/// </summary>
	public CustomerId CustomerId { get; }

	/// <summary>
	/// Order identifier.
	/// </summary>
	public OrderId Id { get; }
}