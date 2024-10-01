using MagCoders.Orders.Modules.Core.Contracts.ValueObjects;
using MagCoders.Orders.Shared.Infrastructure.Events;

namespace MagCoders.Orders.Modules.Core.Contracts.Events.Orders;

/// <summary>
/// Order name updated domain event.
/// </summary>
public class OrderUpdatedDomainEvent : DomainEvent
{
	/// <summary>
	/// Initializes a new instance of the <see cref="OrderUpdatedDomainEvent"/> class.
	/// </summary>
	/// <param name="id">Order identifier.</param>
	/// <param name="newName">New name.</param>
	public OrderUpdatedDomainEvent(OrderId id, string newName)
	{
		this.Id = id;
		this.NewName = newName;
	}

	/// <summary>
	/// Order identifier.
	/// </summary>
	public OrderId Id { get; }

	/// <summary>
	/// New order name.
	/// </summary>
	public string NewName { get; }
}