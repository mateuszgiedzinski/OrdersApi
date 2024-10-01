using System.ComponentModel.DataAnnotations.Schema;
using MagCoders.Orders.Modules.Core.Contracts.Events.Orders;
using MagCoders.Orders.Modules.Core.Contracts.ValueObjects;
using MagCoders.Orders.Shared.Infrastructure;
using MagCoders.Orders.Shared.Infrastructure.Domain;
using MagCoders.Orders.Shared.Infrastructure.Domain.ValueObjects;

namespace MagCoders.Orders.Modules.Core.Domain;

/// <summary>
/// Order of aggregate root.
/// </summary>
public class OrderAggregate : Aggregate, IEntity<OrderId>
{
	private OrderAggregate()
	{
	}

	private OrderAggregate(
		OrderId id,
		CustomerId customerId)
	{
		if (id.Value == Guid.Empty)
		{
			throw new InvalidOperationException("Id value cannot be empty!");
		}

		var orderCreated = new OrderCreatedDomainEvent(id, customerId);
		this.Apply(orderCreated, this.Handle);
	}

	/// <summary>
	/// Order creation date.
	/// </summary>
	public DateTime CreatedOn { get; private set; }

	/// <summary>
	/// Id of the customer which creates the order.
	/// </summary>
	public CustomerId CustomerId { get; private set; }

	/// <summary>
	/// Order identifier.
	/// </summary>
	public OrderId Id { get; private set; }

	/// <summary>
	/// Additional note.
	/// </summary>
	public string? Note { get; private set; }

	/// <summary>
	/// Lines in order. Collection contains all order lines which represents product it's prices and quantities.
	/// </summary>
	[NotMapped]
	public virtual List<OrderLine> OrderLines { get; private set; } = null!;

	/// <summary>
	/// State of the order.
	/// </summary>
	public OrderState State { get; private set; }

	/// <summary>
	/// Value of order.
	/// </summary>
	public Money Overall { get; private set; }

	/// <summary>
	/// Create Order.
	/// </summary>
	/// <param name="id">Unique identifier.</param>
	/// <param name="customerId">Identifier of the customer which creates order.</param>
	/// <returns>New order aggregate.</returns>
	public static OrderAggregate Create(Guid id, CustomerId customerId)
	{
		var orderId = new OrderId(id);
		return new OrderAggregate(orderId, customerId);
	}

	private void Handle(OrderCreatedDomainEvent @event)
	{
		this.Id = @event.Id;
		this.CustomerId = @event.CustomerId;
		this.State = OrderStates.New;
		this.CreatedOn = @event.Timestamp;
		this.OrderLines = new List<OrderLine>();
		this.Overall = default;
	}
}