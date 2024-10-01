namespace MagCoders.Orders.Modules.Core.Contracts.ValueObjects;

/// <summary>
/// Record representing discount value.
/// </summary>
/// <param name="Value">Percentage value of discount.</param>
public record struct Discount(decimal Value);