namespace MagCoders.Orders.Shared.Infrastructure.Domain.ValueObjects;

/// <summary>
/// Money value object.
/// </summary>
public record struct Money
{
	/// <summary>
	/// Initializes a new instance of the <see cref="Money"/> class.
	/// </summary>
	/// <param name="value"> Money quantity. </param>
	/// <param name="currency"> Currency. </param>
	public Money(decimal value, Currency currency)
	{
		this.Value = value;
		this.Currency = currency;
	}

	/// <summary>
	/// Money quantity.
	/// </summary>
	public decimal Value { get; init; }

	/// <summary>
	/// Money currency.
	/// </summary>
	public Currency Currency { get; init; }

	/// <summary>
	/// Implementation of multiply operator for quantity and money.
	/// </summary>
	/// <param name="money">Money value per 1 quantity.</param>
	/// <param name="quantity">Quantity value.</param>
	/// <returns>Value of money times quantity.</returns>
	public static Money operator *(Money money,  Quantity quantity) => new Money(money.Value * quantity.Value, money.Currency);
}