using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MagCoders.Orders.Shared.Infrastructure.Domain.ValueObjects;

/// <summary>
/// Class which holds method for conversion of shared value objects.
/// </summary>
public static class SharedConverters
{
	/// <summary>
	/// Converter which changes CreditCard to string.
	/// </summary>
	/// <returns>Returns Converted CreditCard to string.</returns>
	public static ValueConverter CreditCardConverter() => new ValueConverter<CreditCard, string>(
		creditCard => creditCard.Number,
		number => new CreditCard(number));

	/// <summary>
	/// Converter which changes email to its string representation.
	/// </summary>
	/// <returns>Returns Converted Email address to string.</returns>
	public static ValueConverter EmailConverter() => new ValueConverter<EmailAddress, string>(
		email => email.Value,
		emailValue => new EmailAddress(emailValue));

	/// <summary>
	/// Converter which changes quantity to its int representation.
	/// </summary>
	/// <returns>Returns Converted quantity to int.</returns>
	public static ValueConverter QuantityConverter() => new ValueConverter<Quantity, int>(
		quantity => quantity.Value,
		quantityValue => new Quantity(quantityValue));
}