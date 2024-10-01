using MagCoders.Orders.Modules.Core.Contracts.ValueObjects;
using MagCoders.Orders.Modules.Stock.Contracts.ValueObjects;
using MagCoders.Orders.Shared.Infrastructure;
using MagCoders.Orders.Shared.Infrastructure.Domain.ValueObjects;

namespace MagCoders.Orders.Modules.Core.Domain;

/// <summary>
/// Entity representing single order line. Order can have one or more lines. OrderLine cannot live outside
/// OrderAggregate.
/// </summary>
public record OrderLine : IEntity<OrderLineId>
{
	/// <summary>
	/// Initializes a new instance of the <see cref="OrderLine"/> class.
	/// </summary>
	private OrderLine()
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="OrderLine"/> class.
	/// </summary>
	/// <param name="id">Identifier of order line.</param>
	/// <param name="product">Product identifier.</param>
	/// <param name="quantity">Quantity of products in order line.</param>
	/// <param name="price">Price of order line. It's unit price * quantity.</param>
	/// <param name="unitPrice">Price of product.</param>
	/// <param name="order">Order identifier to which order line belongs.</param>
	/// <exception cref="InvalidOperationException">Throws if order line identifier is not valid.</exception>
	private OrderLine(
		OrderLineId id,
		ProductId product,
		Quantity quantity,
		Money unitPrice,
		Money price,
		OrderId order)
	{
		if (id.Value == Guid.Empty)
		{
			throw new InvalidOperationException("Id value cannot be empty!");
		}

		this.Id = id;
		this.Product = product;
		this.Quantity = quantity;
		this.Price = price;
		this.UnitPrice = unitPrice;
		this.OrderId = order;
	}

	/// <summary>
	/// Discount applied to order line. There can be only one discount applied to order line.
	/// </summary>
	public Discount Discount { get; private set; }

	/// <summary>
	/// Order line identifier.
	/// </summary>
	public OrderLineId Id { get; private set; }

	/// <summary>
	/// Order to which order line belongs.
	/// </summary>
	public OrderId OrderId { get; private set; }

	/// <summary>
	/// Original product price before applying discounts.
	/// </summary>
	public Money OriginalUnitPrice { get; private set; }

	/// <summary>
	/// Price of products in order line. It's equal to UnitPrice * Quantity.
	/// </summary>
	public Money Price { get; private set; }

	/// <summary>
	/// Product identifier.
	/// </summary>
	public ProductId Product { get; private set; }

	/// <summary>
	/// Quantity of product ordered.
	/// </summary>
	public Quantity Quantity { get; private set; }

	/// <summary>
	/// Price of product in line order. Is used to calculate total price of order like Price * Quantity.
	/// </summary>
	public Money UnitPrice { get; private set; }

	/// <summary>
	/// Initialize new instance of OrderLine.
	/// </summary>
	/// <param name="product">Product identifier.</param>
	/// <param name="quantity">Quantity of products in order.</param>
	/// <param name="unitPrice">Price of product.</param>
	/// <param name="orderId">Order identifier to which order line belongs.</param>
	/// <returns>Created <see cref="OrderLine"/>.</returns>
	public OrderLine Create(
		ProductId product,
		Quantity quantity,
		Money unitPrice,
		OrderId orderId)
	{
		var orderLineId = new OrderLineId(Guid.NewGuid());
		return new OrderLine(orderLineId, product, quantity, unitPrice, quantity * unitPrice, orderId);
	}
}