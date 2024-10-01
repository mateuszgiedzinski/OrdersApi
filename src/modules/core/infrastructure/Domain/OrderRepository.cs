using MagCoders.Orders.Modules.Core.Contracts.ValueObjects;
using MagCoders.Orders.Modules.Core.Domain;
using MagCoders.Orders.Modules.Core.Infrastructure.Data;
using MagCoders.Orders.Shared.Abstractions.Events;
using MagCoders.Orders.Shared.Infrastructure;
using MagCoders.Orders.Shared.Infrastructure.EventDispachers;

namespace MagCoders.Orders.Modules.Core.Infrastructure.Domain;

/// <summary>
/// Order aggregate repository.
/// </summary>
public class OrderRepository : BaseRepository<OrderAggregate, OrderId>
{
	/// <summary>
	/// Initializes a new instance of the <see cref="OrderRepository"/> class.
	/// </summary>
	/// <param name="orderDbContext">Database context.</param>
	/// <param name="domainEventDispatcher">Event dispatcher.</param>
	public OrderRepository(CoreDbContext orderDbContext, IEventDispatcher<IEvent> domainEventDispatcher)
		: base(orderDbContext, domainEventDispatcher)
	{
	}
}