using MagCoders.Orders.Shared.Abstractions.Attributes;
using MagCoders.Orders.Shared.Abstractions.Commands;
using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace MagCoders.Orders.Shared.Infrastructure.Commands.CommandBus;

/// <summary>
/// Command Bus implementation.
/// </summary>
[Lifetime(Lifetime = ServiceLifetime.Singleton)]
public class CommandBus : ICommandBus
{
	private readonly IMediator mediator;

	/// <summary>
	/// Initializes a new instance of the <see cref="CommandBus"/> class.
	/// </summary>
	/// <param name="mediator">Mediator injection.</param>
	public CommandBus(IMediator mediator)
	{
		this.mediator = mediator;
	}

	/// <inheritdoc/>
	public Task Send<TCommand>(TCommand command)
		where TCommand : ICommand
	{
		return this.mediator.Send(command);
	}
}