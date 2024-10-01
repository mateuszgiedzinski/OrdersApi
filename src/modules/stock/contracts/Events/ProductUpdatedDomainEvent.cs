using MagCoders.Orders.Modules.Stock.Contracts.ValueObjects;
using MagCoders.Orders.Shared.Infrastructure.Events;

namespace MagCoders.Orders.Modules.Stock.Contracts.Events;

/// <summary>
/// Order name updated domain event.
/// </summary>
public class ProductUpdatedDomainEvent : DomainEvent
{
	/// <summary>
	/// Initializes a new instance of the <see cref="ProductUpdatedDomainEvent"/> class.
	/// </summary>
	/// <param name="id">Order identifier.</param>
	/// <param name="newName">New name.</param>
	public ProductUpdatedDomainEvent(ProductId id, string newName)
	{
		this.Id = id;
		this.NewName = newName;
	}

	/// <summary>
	/// Order identifier.
	/// </summary>
	public ProductId Id { get; }

	/// <summary>
	/// New order name.
	/// </summary>
	public string NewName { get; }
}