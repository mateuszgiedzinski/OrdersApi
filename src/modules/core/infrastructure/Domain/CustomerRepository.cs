using MagCoders.Orders.Modules.Core.Contracts.ValueObjects;
using MagCoders.Orders.Modules.Core.Domain;
using MagCoders.Orders.Modules.Core.Infrastructure.Data;
using MagCoders.Orders.Shared.Abstractions.Events;
using MagCoders.Orders.Shared.Infrastructure;
using MagCoders.Orders.Shared.Infrastructure.EventDispachers;

namespace MagCoders.Orders.Modules.Core.Infrastructure.Domain;

/// <summary>
/// Customer aggregate repository.
/// </summary>
public class CustomerRepository : BaseRepository<CustomerAggregate, CustomerId>
{
	/// <summary>
	/// Initializes a new instance of the <see cref="CustomerRepository"/> class.
	/// </summary>
	/// <param name="coreDbContext">Database context.</param>
	/// <param name="domainEventDispatcher">Event dispatcher.</param>
	public CustomerRepository(CoreDbContext coreDbContext, IEventDispatcher<IEvent> domainEventDispatcher)
		: base(coreDbContext, domainEventDispatcher)
	{
	}
}