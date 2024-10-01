using MagCoders.Orders.Shared.Infrastructure;

namespace MagCoders.Orders.Modules.Core.Contracts.ValueObjects;

/// <summary>
/// Representation of customer Id.
/// </summary>
/// <param name="Value">Value of Id.</param>
public record struct CustomerId(Guid Value) : IEntityId<Guid>;