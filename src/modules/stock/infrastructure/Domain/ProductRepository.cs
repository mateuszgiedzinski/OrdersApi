using MagCoders.Orders.Modules.Stock.Contracts.ValueObjects;
using MagCoders.Orders.Modules.Stock.Domain;
using MagCoders.Orders.Modules.Stock.Infrastructure.Data;
using MagCoders.Orders.Shared.Abstractions.Events;
using MagCoders.Orders.Shared.Infrastructure;
using MagCoders.Orders.Shared.Infrastructure.EventDispachers;

namespace MagCoders.Orders.Modules.Stock.Infrastructure.Domain;

/// <summary>
/// Product aggregate repository.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ProductRepository"/> class.
/// </remarks>
/// <param name="stockDbContext">Database context.</param>
/// <param name="domainEventDispatcher">Event dispatcher.</param>
public class ProductRepository(StockDbContext stockDbContext, IEventDispatcher<IEvent> domainEventDispatcher)
	: BaseRepository<ProductAggregate, ProductId>(stockDbContext, domainEventDispatcher)
{
}