using MagCoders.Orders.Shared.Abstractions.Domain;
using MagCoders.Orders.Shared.Abstractions.Events;
using MagCoders.Orders.Shared.Infrastructure.Events;

namespace MagCoders.Orders.Shared.Infrastructure.Domain;

/// <summary>
/// Base Aggregate class.
/// </summary>
public abstract class Aggregate
{
	/// <summary>
	/// List of aggregate uncommited events.
	/// </summary>
	public List<IEvent> UncommittedEvents { get; } = new();

	/// <summary>
	/// Applies an event.
	/// </summary>
	/// <param name="event">Event.</param>
	/// <param name="eventHandleMethod">Handler.</param>
	/// <typeparam name="TEvent">Domain event.</typeparam>
	protected void Apply<TEvent>(TEvent @event, Action<TEvent> eventHandleMethod)
		where TEvent : DomainEvent
	{
		eventHandleMethod(@event);
		this.UncommittedEvents.Add(@event);
	}

	/// <summary>
	/// Checks business rule.
	/// </summary>
	/// <param name="rule">Business rule.</param>
	protected void CheckRule(IBusinessRule rule)
	{
		if (rule.IsBroken())
		{
			throw new BusinessRuleValidationException(rule.RuleName);
		}
	}
}