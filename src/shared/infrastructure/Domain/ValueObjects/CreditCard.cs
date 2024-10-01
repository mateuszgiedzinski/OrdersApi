namespace MagCoders.Orders.Shared.Infrastructure.Domain.ValueObjects;

/// <summary>
/// Record representing credit card.
/// </summary>
/// <param name="Number">Number.</param>
public record struct CreditCard(string Number);