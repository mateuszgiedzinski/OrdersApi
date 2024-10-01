using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MagCoders.Orders.Modules.Stock.Contracts.ValueObjects;

/// <summary>
/// Class which holds method for Id conversion.
/// </summary>
public static class ProductConverters
{
	/// <summary>
	/// Converter which changes OrderId to Guid.
	/// </summary>
	/// <returns>Returns Converted OrderId to guid.</returns>
	public static ValueConverter ProductIdConverter()
	{
		return new ValueConverter<ProductId, Guid>(
			id => id.Value,
			guid => new ProductId(guid));
	}
}