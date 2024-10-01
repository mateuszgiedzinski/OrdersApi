using MagCoders.Orders.Modules.Stock.Contracts.ValueObjects;
using MagCoders.Orders.Modules.Stock.Domain;
using MagCoders.Orders.Shared.Abstractions.Commands;
using MagCoders.Orders.Shared.Abstractions.Domain;

namespace MagCoders.Orders.Modules.Stock.Application.Product.CreatingProduct;

/// <summary>
/// Create order command.
/// </summary>
/// <param name="Id">Order identifier.</param>
/// <param name="Name">Order name.</param>
public record CreateProduct(Guid Id, string Name) : ICommand;

/// <summary>
/// Create order command handler implementation.
/// </summary>
public class CreateProductHandler : ICommandHandler<CreateProduct>
{
	private readonly IRepository<ProductAggregate, ProductId> orderRepository;

	/// <summary>
	/// Initializes a new instance of the <see cref="CreateProductHandler"/> class.
	/// </summary>
	/// <param name="orderRepository">Repository that manages example aggregate root.</param>
	public CreateProductHandler(IRepository<ProductAggregate, ProductId> orderRepository)
	{
		this.orderRepository = orderRepository;
	}

	/// <inheritdoc/>
	public async Task Handle(CreateProduct command, CancellationToken cancellationToken)
	{
		var example = ProductAggregate.Create(command.Id, command.Name);

		await this.orderRepository.Persist(example);
	}
}