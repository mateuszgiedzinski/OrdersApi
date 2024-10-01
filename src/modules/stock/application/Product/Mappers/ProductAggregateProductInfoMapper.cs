using MagCoders.Orders.Modules.Stock.Application.Product.GettingProducts;
using MagCoders.Orders.Modules.Stock.Domain;

namespace MagCoders.Orders.Modules.Stock.Application.Product.Mappers;

/// <summary>
/// Mapper class.
/// </summary>
public static class ProductAggregateProductInfoMapper
{
	/// <summary>
	/// Mapping method.
	/// </summary>
	/// <param name="entity">Entity to be mapped.</param>
	/// <returns>Returns <seealso cref="ProductInfo"/>.</returns>
	public static ProductInfo Map(ProductAggregate entity)
	{
		return new(entity.Id.Value, entity.Name, entity.CreatedOn);
	}
}