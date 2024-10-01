using MagCoders.Orders.Shared.Abstractions.Events;

using MediatR;

namespace MagCoders.Orders.Shared.Infrastructure.EventDispachers;

/// <summary>
/// Domain event dispatcher.
/// </summary>
public class DomainEventDispatcher : IEventDispatcher<IEvent>
{
	private readonly IMediator mediator;

	/// <summary>
	/// Initializes a new instance of the <see cref="DomainEventDispatcher"/> class.
	/// Constructor of domain event dispatcher.
	/// </summary>
	/// <param name="mediator">Mediator.</param>
	public DomainEventDispatcher(IMediator mediator)
	{
		this.mediator = mediator;
	}

	/// <inheritdoc/>
	public async Task Publish(List<IEvent> eventsList)
	{
		// TODO: Add logging using ILogger
		var tasks = eventsList.Select(x => this.mediator.Publish(x));
		await Task.WhenAll(tasks);
	}
}