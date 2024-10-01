using MagCoders.Orders.Modules.Stock.Contracts.Events;
using MagCoders.Orders.Modules.Stock.Contracts.ValueObjects;
using MagCoders.Orders.Modules.Stock.Domain.Rules;
using MagCoders.Orders.Shared.Infrastructure;
using MagCoders.Orders.Shared.Infrastructure.Domain;

namespace MagCoders.Orders.Modules.Stock.Domain;

/// <summary>
/// Order of aggregate root.
/// </summary>
public class ProductAggregate : Aggregate, IEntity<ProductId>
{
	private ProductAggregate()
	{
	}

	private ProductAggregate(ProductId id, string name)
	{
		if (id.Value == Guid.Empty)
		{
			throw new InvalidOperationException("Id value cannot be empty!");
		}

		var orderCreated = new ProductCreatedDomainEvent(id, name);
		this.Apply(orderCreated, this.Handle);
	}

	/// <summary>
	/// Order creation date.
	/// </summary>
	public DateTime CreatedOn { get; private set; }

	/// <summary>
	/// Order identifier.
	/// </summary>
	public ProductId Id { get; private set; }

	/// <summary>
	/// Order name.
	/// </summary>
	public string Name { get; private set; } = default!;

	/// <summary>
	/// Create Order.
	/// </summary>
	/// <param name="id">Unique identifier.</param>
	/// <param name="name">Order name.</param>
	/// <returns>New aggregate.</returns>
	public static ProductAggregate Create(Guid id, string name)
	{
		var orderId = new ProductId(id);
		return new ProductAggregate(orderId, name);
	}

	/// <summary>
	/// Update Order name.
	/// </summary>
	/// <param name="name">New name.</param>
	public void UpdateName(string name)
	{
		this.CheckRule(new ProductCannotHaveNameStartedWithBrokenRuleBusinessRule(name));

		var evt = new ProductUpdatedDomainEvent(this.Id, name);

		this.Apply(evt, this.Handle);
	}

	private void Handle(ProductUpdatedDomainEvent @event)
	{
		this.Name = @event.NewName;
	}

	private void Handle(ProductCreatedDomainEvent @event)
	{
		this.Id = @event.Id;
		this.Name = @event.Name;
		this.CreatedOn = @event.Timestamp;
	}
}