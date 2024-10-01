using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MagCoders.Orders.Modules.Core.Contracts.ValueObjects;

/// <summary>
/// Class which holds method for conversion of value objects for customer aggregate.
/// </summary>
public static class CustomerConverters
{
	/// <summary>
	/// Converter which changes CustomerId to Guid.
	/// </summary>
	/// <returns>Returns Converted CustomerId to guid.</returns>
	public static ValueConverter CustomerIdConverter()
	{
		return new ValueConverter<CustomerId, Guid>(
			id => id.Value,
			guid => new CustomerId(guid));
	}

	/// <summary>
	/// Converter which changes customer level to its int code representation.
	/// </summary>
	/// <returns>Returns Converted CustomerLevel to integer code value.</returns>
	public static ValueConverter CustomerLevelConverter()
	{
		return new ValueConverter<CustomerLevel, int>(
			level => level.Code,
			code => CustomerLevel.CreateFromCode(code));
	}
}