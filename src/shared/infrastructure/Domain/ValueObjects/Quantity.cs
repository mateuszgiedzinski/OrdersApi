namespace MagCoders.Orders.Shared.Infrastructure.Domain.ValueObjects;

/// <summary>
/// Represents quantity.
/// </summary>
/// <param name="Value">Value of quantity.</param>
public record struct Quantity(int Value)
{
	/// <summary>
	/// Implementation of multiply operator for quantity and money.
	/// </summary>
	/// <param name="money">Money value per 1 quantity.</param>
	/// <param name="quantity">Quantity value.</param>
	/// <returns>Value of money times quantity.</returns>
	public static Money operator *(Quantity quantity, Money money) => new Money(money.Value * quantity.Value, money.Currency);
}