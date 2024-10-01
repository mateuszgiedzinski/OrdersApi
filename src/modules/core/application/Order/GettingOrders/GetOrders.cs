using MagCoders.Orders.Modules.Core.Application.Order.Mappers;
using MagCoders.Orders.Modules.Core.Infrastructure.Data;
using MagCoders.Orders.Shared.Abstractions;
using MagCoders.Orders.Shared.Abstractions.Queries;

using Microsoft.EntityFrameworkCore;

namespace MagCoders.Orders.Modules.Core.Application.Order.GettingOrders;

/// <summary>
/// Get orders query.
/// </summary>
public record GetOrders() : IQuery<PagedList<OrderInfo>>;

/// <summary>
/// Get orders handler.
/// </summary>
public class GetOrdersQueryHandler : IQueryHandler<GetOrders, PagedList<OrderInfo>>
{
	private readonly CoreDbContext orderDbContext;

	/// <summary>
	/// Initializes a new instance of the <see cref="GetOrdersQueryHandler"/> class.
	/// </summary>
	/// <param name="orderDbContext">Order dbContext.</param>
	public GetOrdersQueryHandler(CoreDbContext orderDbContext)
	{
		this.orderDbContext = orderDbContext;
	}

	/// <summary>
	/// GetOrders query handler.
	/// </summary>
	/// <param name="query">Query.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>Paged list of examples.</returns>
	public async Task<PagedList<OrderInfo>> Handle(GetOrders query, CancellationToken cancellationToken)
	{
		var examples = await this.orderDbContext.Orders.OrderBy(x => x.Id).ToListAsync();
		var mappedData = examples.Select(OrderAggregateOrderInfoMapper.Map).ToList();
		var result = new PagedList<OrderInfo> { Items = mappedData };
		return result;
	}
}