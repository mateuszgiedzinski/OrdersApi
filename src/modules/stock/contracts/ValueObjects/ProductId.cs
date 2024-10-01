using MagCoders.Orders.Shared.Infrastructure;

namespace MagCoders.Orders.Modules.Stock.Contracts.ValueObjects;

/// <summary>
/// Record which represents Order Id.
/// </summary>
public record struct ProductId(Guid Value) : IEntityId<Guid>;