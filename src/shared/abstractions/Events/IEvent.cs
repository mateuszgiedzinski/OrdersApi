using MediatR;

namespace MagCoders.Orders.Shared.Abstractions.Events;

/// <summary>
/// Base event interface.
/// </summary>
public interface IEvent : INotification
{
	/// <summary>
	/// Event timestamp.
	/// </summary>
	public DateTime Timestamp { get; set; }
}