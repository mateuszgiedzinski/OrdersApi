using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MagCoders.Orders.Modules.Core.Contracts.ValueObjects;

/// <summary>
/// Class which holds method for Id conversion.
/// </summary>
public static class OrderConverters
{
	/// <summary>
	/// Converter which changes OrderId to Guid.
	/// </summary>
	/// <returns>Returns Converted OrderId to guid.</returns>
	public static ValueConverter OrderIdConverter()
	{
		return new ValueConverter<OrderId, Guid>(
			id => id.Value,
			guid => new OrderId(guid));
	}

	/// <summary>
	/// Converter which changes OrderLineId to Guid.
	/// </summary>
	/// <returns>Returns Converted OrderLineId to guid.</returns>
	public static ValueConverter OrderLineIdConverter()
	{
		return new ValueConverter<OrderLineId, Guid>(
			id => id.Value,
			guid => new OrderLineId(guid));
	}

	/// <summary>
	/// Converter which changes order state to integer representation.
	/// </summary>
	/// <returns>Returns Converted OrderId to guid.</returns>
	public static ValueConverter OrderStateConverter()
	{
		return new ValueConverter<OrderState, int>(
			state => state.Code,
			value => OrderState.Create(value));
	}

	/// <summary>
	/// Converter which changes order state to integer representation.
	/// </summary>
	/// <returns>Returns Converted OrderId to guid.</returns>
	public static ValueConverter DiscountConverter()
	{
		return new ValueConverter<Discount, decimal>(
			discount => discount.Value,
			value => new Discount(value));
	}
}