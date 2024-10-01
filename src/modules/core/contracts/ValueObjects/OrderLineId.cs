using MagCoders.Orders.Shared.Infrastructure;

namespace MagCoders.Orders.Modules.Core.Contracts.ValueObjects;

/// <summary>
/// Record which represents Order line Id.
/// </summary>
public record struct OrderLineId(Guid Value) : IEntityId<Guid>;