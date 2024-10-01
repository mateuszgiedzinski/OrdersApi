using MagCoders.Orders.Modules.Stock.Contracts.ValueObjects;
using MagCoders.Orders.Shared.Infrastructure.Events;

namespace MagCoders.Orders.Modules.Stock.Contracts.Events;

/// <summary>
/// Order created domain event.
/// </summary>
public class ProductCreatedDomainEvent : DomainEvent
{
	/// <summary>
	/// Initializes a new instance of the <see cref="ProductCreatedDomainEvent"/> class.
	/// </summary>
	/// <param name="id">Order identifier.</param>
	/// <param name="name">Order name.</param>
	public ProductCreatedDomainEvent(ProductId id, string name)
	{
		this.Id = id;
		this.Name = name;
	}

	/// <summary>
	/// Order identifier.
	/// </summary>
	public ProductId Id { get; }

	/// <summary>
	/// Order name.
	/// </summary>
	public string Name { get; }
}