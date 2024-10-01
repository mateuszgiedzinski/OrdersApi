using MagCoders.Orders.Shared.Infrastructure;

namespace MagCoders.Orders.Modules.Core.Contracts.ValueObjects;

/// <summary>
/// Record which represents Order Id.
/// </summary>
public record struct OrderId(Guid Value) : IEntityId<Guid>;