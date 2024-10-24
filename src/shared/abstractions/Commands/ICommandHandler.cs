namespace MagCoders.Orders.Shared.Abstractions.Commands;

/// <summary>
/// Interface of command handler.
/// </summary>
/// <typeparam name="T">Type of command to handle.</typeparam>
public interface ICommandHandler<T>
{
	/// <summary>
	/// Handles command.
	/// </summary>
	/// <param name="command">Command to handle.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>Task representing asynchronous operation.</returns>
	Task Handle(T command, CancellationToken cancellationToken);
}