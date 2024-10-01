namespace MagCoders.Orders.Shared.Infrastructure.Domain.ValueObjects;

/// <summary>
/// Record representing email address.
/// </summary>
/// <param name="Value">Email address string value.</param>
public record struct EmailAddress(string Value);