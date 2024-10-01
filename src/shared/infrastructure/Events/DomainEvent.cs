using MagCoders.Orders.Shared.Abstractions.Events;

namespace MagCoders.Orders.Shared.Infrastructure.Events;

/// <summary>
/// Domain event base class.
/// </summary>
public abstract class DomainEvent : IEvent
{
	/// <inheritdoc />
	public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}