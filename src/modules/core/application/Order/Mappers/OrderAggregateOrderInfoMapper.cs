using MagCoders.Orders.Modules.Core.Application.Order.GettingOrders;
using MagCoders.Orders.Modules.Core.Domain;

namespace MagCoders.Orders.Modules.Core.Application.Order.Mappers;

/// <summary>
/// Mapper class.
/// </summary>
public static class OrderAggregateOrderInfoMapper
{
	/// <summary>
	/// Mapping method.
	/// </summary>
	/// <param name="entity">Entity to be mapped.</param>
	/// <returns>Returns <seealso cref="OrderInfo"/>.</returns>
	public static OrderInfo Map(OrderAggregate entity)
	{
		return new(entity.Id.Value, string.Empty, entity.CreatedOn);
	}
}