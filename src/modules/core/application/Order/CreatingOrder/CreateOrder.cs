using MagCoders.Orders.Modules.Core.Contracts.ValueObjects;
using MagCoders.Orders.Modules.Core.Domain;
using MagCoders.Orders.Shared.Abstractions.Commands;
using MagCoders.Orders.Shared.Abstractions.Domain;

namespace MagCoders.Orders.Modules.Core.Application.Order.CreatingOrder;

/// <summary>
/// Create order command.
/// </summary>
/// <param name="Id">Order identifier.</param>
/// <param name="CusomerId">Customer identifier.</param>
public record CreateOrder(
	Guid Id,
	Guid CusomerId) : ICommand;

/// <summary>
/// Create order command handler implementation.
/// </summary>
public class CreateOrderHandler : ICommandHandler<CreateOrder>
{
	private readonly IRepository<OrderAggregate, OrderId> orderRepository;

	/// <summary>
	/// Initializes a new instance of the <see cref="CreateOrderHandler"/> class.
	/// </summary>
	/// <param name="orderRepository">Repository that manages example aggregate root.</param>
	public CreateOrderHandler(IRepository<OrderAggregate, OrderId> orderRepository)
	{
		this.orderRepository = orderRepository;
	}

	/// <inheritdoc/>
	public async Task Handle(CreateOrder command, CancellationToken cancellationToken)
	{
		var order = OrderAggregate.Create(command.Id, new CustomerId(command.CusomerId));

		await this.orderRepository.Persist(order);
	}
}